using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace SCADA_APP
{
    public partial class frHome : Form
    {
        int counter_data = 0;
        int counter = 0;
        public frHome()
        {
            InitializeComponent();
        }
        #region Image Processing

        Mat imgRaw = new Mat(), imgProcess = new Mat(), imgProcess2 = new Mat(),
            imgRS = new Mat(), imgRS2 = new Mat(), imgInran = new Mat(), imgZero = new Mat(), imgCap = new Mat();

        private void numScore_ValueChanged(object sender, EventArgs e)
        {
            //Score = int.Parse(txtScore.Text);
        }

        VideoCapture cam = new VideoCapture();

        public bool Connect(int indexCamera)
        {
            cam.Open(indexCamera);
            if (cam.IsOpened())
            {
                btnRecord.Enabled = true;
                return true;
            }
            else
            {
                btnRecord.Enabled = false;
            }
            return false;
        }
        public void Cap()
        {
            //cam.Read(imgRaw);
            cam.Read(imgRaw);
            picCamera.ImageIpl = imgRaw;

        }

        public void XuLyAnh()
        {
            if (imgRaw != null)
            {

                imgProcess = imgRaw.Clone();
                
                Cv2.GaussianBlur(imgRaw, imgProcess, new OpenCvSharp.Size(5, 5), 0);
                Cv2.CvtColor(imgProcess, imgProcess, ColorConversionCodes.BGR2HSV);
                Cv2.CvtColor(imgProcess, imgProcess, ColorConversionCodes.BGR2GRAY);
                Cv2.Threshold(imgProcess, imgProcess, 0, 255, ThresholdTypes.Otsu);
                //picProcess.ImageIpl = imgProcess;
                Cv2.MorphologyEx(imgProcess, imgProcess, MorphTypes.Dilate, null);

                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchies;
                int indexContourMax = 0;
                double areaMax = 0;
                double areaMax1;
                Cv2.FindContours(imgProcess.Clone(), out contours, out hierarchies, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                int i = 0;
                foreach (OpenCvSharp.Point[] contour in contours)
                {
                    double area = Cv2.ContourArea(contour);
                    if (area > areaMax)
                    {
                        areaMax = area;
                        indexContourMax = i;
                    }
                    i++;
                }

                areaMax1 = Math.Round (Math.Sqrt(areaMax / (4616 * 3.14)), 2);

                Cv2.CvtColor(imgProcess, imgProcess, ColorConversionCodes.GRAY2BGR);
                Cv2.BitwiseAnd(imgRaw, imgProcess, imgRS2);
                Cv2.CvtColor(imgRS2, imgZero, ColorConversionCodes.BGR2GRAY);
                int px1 = Cv2.CountNonZero(imgZero);
                Cv2.InRange(imgRS2, new Scalar(0, 0, 50), new Scalar(110, 110, 255), imgInran);
                int pxInrange = Cv2.CountNonZero(imgInran);
                Cv2.CvtColor(imgInran, imgRS, ColorConversionCodes.GRAY2BGR);
                double percent = (pxInrange / (px1 * 1.0)) * 100.0;
                percent = Math.Round(percent);
                Cv2.DrawContours(imgRS, contours, indexContourMax, Scalar.Blue, 8);
                picProcess.ImageIpl = imgRS;
                lbScore.Text = percent.ToString();
                lbArea.Text = areaMax1.ToString();


                if (areaMax > minSize)
                {
                    lbStatusArea.Text = "Standard Size";
                    lbStatusArea.ForeColor = Color.MediumBlue;

                    if (percent >= minColor1 && percent <= maxColor1)
                    {
                        PLC.Instance().SetBit("DB1.DBX0.6");
                        PLC.Instance().ResetBit("DB1.DBX0.6");
                        lbStatus.Text = "Green Tomato";
                        lbStatus.ForeColor = Color.Green;
                    }
                    if (percent >= minColor2 && percent <= maxColor2)
                    {
                        PLC.Instance().SetBit("DB1.DBX0.5");
                        PLC.Instance().ResetBit("DB1.DBX0.5");
                        lbStatus.Text = "Orange Tomato";
                        lbStatus.ForeColor = Color.Orange;
                    }
                    if (percent >= minColor3 && percent <= maxColor3)
                    {
                        PLC.Instance().SetBit("DB1.DBX0.4");
                        PLC.Instance().ResetBit("DB1.DBX0.4");
                        lbStatus.Text = "Red Tomato";
                        lbStatus.ForeColor = Color.Red;
                    }
                }
                if (areaMax < minSize)
                {
                    PLC.Instance().SetBit("DB1.DBX0.7");
                    // PLC.Instance().ResetBit("DB1.DBX0.7");
                    lbStatus.Text = "";
                    lbStatusArea.Text = "Non-standard Size";
                }
            }
        }
        int minSize;
        int minColor1;
        int maxColor1;
        int minColor2;
        int maxColor2;
        int minColor3;
        int maxColor3;
        private void btnSaveColor_Click(object sender, EventArgs e)
        {
            if (txtMinSize.Text == "" || txtMin1.Text == "" || txtMax1.Text == "" || txtMin2.Text == "" || txtMax2.Text == "" || txtMin3.Text == "" || txtMax3.Text == "")
            {
                MessageBox.Show("Please fill in Size and Color !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                minSize = int.Parse(txtMinSize.Text);
                minColor1 = int.Parse(txtMin1.Text);
                maxColor1 = int.Parse(txtMax1.Text);
                minColor2 = int.Parse(txtMin2.Text);
                maxColor2 = int.Parse(txtMax2.Text);
                minColor3 = int.Parse(txtMin3.Text);
                maxColor3 = int.Parse(txtMax3.Text);
            }
        }

        #endregion
  
        private void timerSignal_Tick(object sender, EventArgs e)
        {
            if (PLCRead.Instance().Process)
            {
                IsRecord = false;
                XuLyAnh();
            }
            else 
            {
                    if (cam.IsOpened())
                    {
                        IsRecord = !IsRecord;
                        if (IsRecord)
                        {
                            if (!wRecord.IsBusy)
                                wRecord.RunWorkerAsync();
                        }
                    }
            }
        }

        private void wRecord_DoWork(object sender, DoWorkEventArgs e)
        {
            cam.Read(imgRaw);
        }
        bool IsRecord = false;

        private void wRecord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (imgRaw != null)
            {
                Bitmap bitmap = null;

                if (picCamera.ImageIpl != null)
                {

                    bitmap = picCamera.ImageIpl.ToBitmap() as Bitmap;

                }

                picCamera.ImageIpl = imgRaw;
                if (bitmap != null)
                {

                    bitmap.Dispose();
                }
                if (IsRecord)
                    wRecord.RunWorkerAsync();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            cam.Read(imgRaw);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG|*.png|JPG|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgRaw = Cv2.ImRead(openFileDialog.FileName);
                picCamera.ImageIpl = imgRaw;
            }
        }

        private void btnCap_Click(object sender, EventArgs e)
        {
            IsRecord = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (cam.IsOpened())
            {
                IsRecord = !IsRecord;
                if (IsRecord)
                {
                    if (!wRecord.IsBusy)
                        wRecord.RunWorkerAsync();
                }
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            XuLyAnh();

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Connect(0);
            if (cam.IsOpened())
            {
                IsRecord = !IsRecord;
                if (IsRecord)
                {
                    if (!wRecord.IsBusy)
                        wRecord.RunWorkerAsync();
                }
            }
        }
        private void frHome_Load(object sender, EventArgs e)
        {
            txtMinSize.Text = "75000";
            txtMin1.Text = "0";
            txtMax1.Text = "30";
            txtMin2.Text = "31";
            txtMax2.Text = "90";
            txtMin3.Text = "91";
            txtMax3.Text = "100";

            timerSignal.Enabled = true;
            timerUpdate.Enabled = true;
            timerHome.Interval = 100;
            timerHome.Enabled = true;

            ProgressBar_Total.Minimum = 0;
            ProgressBar_Total.Maximum = 100;
            ProgressBar_Total.Value = 0;

            ProgressBar_TotalBox.Minimum = 0;
            ProgressBar_TotalBox.Maximum = 25;
            ProgressBar_TotalBox.Value = 0;

            ProgressBar_Error.Minimum = 0;
            ProgressBar_Error.Maximum = 25;
            ProgressBar_Error.Value = 0;

            ProgressBar_Green.Minimum = 0;
            ProgressBar_Green.Maximum = 25;
            ProgressBar_Green.Value = 0;

            ProgressBar_Red.Minimum = 0;
            ProgressBar_Red.Maximum = 25;
            ProgressBar_Red.Value = 0;

            ProgressBar_Orange.Minimum = 0;
            ProgressBar_Orange.Maximum = 25;
            ProgressBar_Orange.Value = 0;
        }

        public void showForm(Form form)
        {
            form.TopMost = true;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
        }
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frReport frview = new frReport();
            showForm(frview);
            panelLoader.Controls.Add(frview);
            frview.BringToFront();
            frview.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frSetting frsetting = new frSetting();
            showForm(frsetting);
            panelLoader.Controls.Add(frsetting);
            frsetting.BringToFront();
            frsetting.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frUser fruser = new frUser();
            showForm(fruser);
            panelLoader.Controls.Add(fruser);
            fruser.BringToFront();
            fruser.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frAbout frabout = new frAbout();
            showForm(frabout);
            panelLoader.Controls.Add(frabout);
            frabout.BringToFront();
            frabout.Show();
        }
        public void Show_Data(Label lb, int value)
        {
            lb.Text = value.ToString();
        } 
        private void timerHome_Tick(object sender, EventArgs e)
        {
            counter++;
            counter_data++;
            PLC.Instance().ReadClass(PLCRead.Instance(), 2);
            PLC.Instance().ReadClass(PLCWrite.Instance(), 3);

            Show_Data(lbTotal, 40);
            Show_Data(lbRed, 11);
            Show_Data(lbOrange, 14);
            Show_Data(lbGreen, 8);
            Show_Data(lbError, 7);
        
            Show_Data(lbType1, 2);
            Show_Data(lbType2, 2);
            Show_Data(lbType3, 2);
            Show_Data(lbType4, 1);

            Show_Data(lbBox1, 3);
            Show_Data(lbBox2, 4);
            Show_Data(lbBox3, 2);
            Show_Data(lbBox4, 2);
            Show_Data(lbTotalBox, 11);

            ProgressBar_TotalBox.Value = int.Parse(lbTotalBox.Text);
            ProgressBar_Total.Value = int.Parse(lbTotal.Text);
            ProgressBar_Red.Value = int.Parse(lbRed.Text);
            ProgressBar_Orange.Value = int.Parse(lbOrange.Text);
            ProgressBar_Green.Value = int.Parse(lbGreen.Text);
            ProgressBar_Error.Value = int.Parse(lbError.Text);

            if (PLCRead.Instance().Light_Start)
            {
                sdStart.DiscreteValue1 = true;
            }
            else
            {
                sdStart.DiscreteValue1 = false;
            }


            if (PLCRead.Instance().Light_Start)
            {
                sdMotor.DiscreteValue1 = true;
            }
            else
            {
                sdMotor.DiscreteValue1 = false;
            }

            if (counter_data >= (Properties.Settings.Default.UpdateTime)*10)
            {
                counter_data = 0;
                SQL.Instance().Insert_Data();
                SQL.Instance().Insert_BoxData();
                SQL.Instance().Insert_Alarm();
            }
        }
        private void frHome_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.btnAcong.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            g.DrawEllipse(pen, 10, 10, 20, 20);
        }

        private void frHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Dispose();
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnAuto.BackColor = Color.SteelBlue;
            PLC.Instance().SetBit("DB1.DBX1.0");
        }

        private void btnAcong_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB3.DBX0.0");
        }

        private void btnAtru_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB3.DBX0.1");
        }

        private void btnBcong_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB3.DBX0.2");
        }

        private void btnBtru_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB3.DBX0.3");
        }

        private void btnCcong_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB3.DBX0.4");
        }

        private void btnCtru_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.5");
        }

        private void btnAcong_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.0");
        }

        private void btnAtru_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.1");
        }

        private void btnBcong_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.2");
        }

        private void btnBtru_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.3");
        }

        private void btnCcong_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.4");
        }

        private void btnCtru_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB3.DBX0.5");
        }
        private void btnManual_Click(object sender, EventArgs e)
        {
            btnManual.BackColor = Color.RoyalBlue;
            btnAuto.BackColor = Color.FromArgb(125, 168, 227);
            PLC.Instance().ResetBit("DB1.DBX1.0");
            lbMode.Text = "Manual Mode";
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            btnAuto.BackColor = Color.RoyalBlue;
            btnManual.BackColor = Color.FromArgb(125, 168, 227);
            PLC.Instance().SetBit("DB1.DBX1.0");
            lbMode.Text = "Auto Mode";
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManual_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.0");
        }

        private void btnManual_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.0");
        }

        private void btnAuto_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.1");
        }

        private void btnAuto_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.1");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Thread _Thread = new Thread(new ThreadStart(Show_frLogin));
            //_Thread.Start();
            //this.Close();
            new frLogin().Show();
            this.Hide();
        }
        private void Show_frLogin()
        {
            frLogin _frShow = new frLogin();
            _frShow.ShowDialog();
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if(txtSetType1.Text == "" || txtSetType2.Text == "" || txtSetType3.Text == "" || txtSetType4.Text == "")
            {
                MessageBox.Show("Please fill all information !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lbSetType1.Text = txtSetType1.Text;
                lbSetType2.Text = txtSetType2.Text;
                lbSetType3.Text = txtSetType3.Text;
                lbSetType4.Text = txtSetType4.Text;

                PLCSetStatic.Quanity_Type1 = short.Parse(txtSetType1.Text);
                PLCSetStatic.Quanity_Type2 = short.Parse(txtSetType2.Text);
                PLCSetStatic.Quanity_Type3 = short.Parse(txtSetType3.Text);
                PLCSetStatic.Quanity_Type4 = short.Parse(txtSetType4.Text);

                PLCWrite.Instance().Quanity_Type1 = PLCSetStatic.Quanity_Type1;
                PLCWrite.Instance().Quanity_Type2 = PLCSetStatic.Quanity_Type2;
                PLCWrite.Instance().Quanity_Type3 = PLCSetStatic.Quanity_Type3;
                PLCWrite.Instance().Quanity_Type4 = PLCSetStatic.Quanity_Type4;

                PLC.Instance().WriteClass(PLCWrite.Instance(), 3);
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {   
            
            DateTime datetime = DateTime.Now;
            lbDate.Text = datetime.ToString("dd/MM/yyyy");
            lbTime.Text = datetime.ToString("HH:mm:ss");
            lbIPAdress.Text = Properties.Settings.Default.IPPLC;
            if (SQL.Instance().SQL_Connected)
            {
                lbStatusSQL.Text = "Connected SQL";
            }
            else
            {
                lbStatusSQL.Text = "Disconnected SQL";
            }
            if (PLC.Instance().PLC_connected)
            {
                lbStatusPLC.Text = "Connected PLC";
            }
            else
            {
                lbStatusPLC.Text = "Disconnected PLC";
            }
        }
        private void btnSetMotor_Click(object sender, EventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.1");
        }

        private void btnResetMotor_Click(object sender, EventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.1");
        }

        private void btnAcong_Click(object sender, EventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.2");
           
        }

        private void btnAtru_Click(object sender, EventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.2");
         
        }

        private void btnBcong_Click(object sender, EventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.3");
        }

        private void btnBtru_Click(object sender, EventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.3");
        }

        private void btnCcong_Click(object sender, EventArgs e)
        {
            PLC.Instance().SetBit("DB1.DBX1.4");
        }

        private void btnCtru_Click(object sender, EventArgs e)
        {
            PLC.Instance().ResetBit("DB1.DBX1.4");
        }

        private void panelLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void standardControl2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            btnStart.Visible = true;
            PLC.Instance().ResetBit("DB1.DBX0.1");
        }
        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            btnStart.Visible = false;

            if (txtMinSize.Text == "" || txtMin1.Text == "" || txtMax1.Text == "" || txtMin2.Text == "" || txtMax2.Text == "" || txtMin3.Text == "" || txtMax3.Text == "")
            {
                MessageBox.Show("Please fill in Size and Color !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PLC.Instance().SetBit("DB1.DBX0.1");
            }
        
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            btnStop.Visible = false;
            PLC.Instance().SetBit("DB1.DBX0.2");
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            btnStop.Visible = true;
            PLC.Instance().ResetBit("DB1.DBX0.2");
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            btnReset.Visible = false;
            PLC.Instance().SetBit("DB1.DBX0.3");    
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            btnReset.Visible = true;
            PLC.Instance().ResetBit("DB1.DBX0.3");
        }
    }
}
