using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace SCADA_APP
{
    public partial class frSetting : Form
    {
        private FilterInfoCollection videoDevicesList;
        private IVideoSource videoSource;

        public frSetting()
        {
            InitializeComponent();
            // get list of video devices
            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDevicesList)
            {
                cmbVideoSource.Items.Add(videoDevice.Name);
            }
            if (cmbVideoSource.Items.Count > 0)
            {
                cmbVideoSource.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // stop the camera on window close
            this.Closing += Form1_Closing;
        }
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // signal to stop
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevicesList[cmbVideoSource.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            videoSource.SignalToStop();
            if (videoSource != null && videoSource.IsRunning && pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
        }
        private void frSetting_Load(object sender, EventArgs e)
        {
            timerSetting.Enabled = true;
            // PLC
            txtIPPLC.Text = Properties.Settings.Default.IPPLC;
            // SQL
            txtSQLPath.Text = Properties.Settings.Default.SQLPath;
            // Update SQL
            txtUpdateTime.Text = Properties.Settings.Default.UpdateTime.ToString();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (PLC.Instance().Open())
            {
                MessageBox.Show("Connect PLC sucessfully !","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Can't connect PLC !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            PLC.Instance().Close();
            MessageBox.Show("Disconnected PLC successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SQLPath = txtSQLPath.Text;
            Properties.Settings.Default.UpdateTime = int.Parse(txtUpdateTime.Text);
            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save information sucessfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.IPPLC = txtIPPLC.Text;
            Properties.Settings.Default.Save();
        }

        private void btnConnectSQL_Click(object sender, EventArgs e)
        {
            SQL.Instance().TestConnection();
            if (SQL.Instance().SQL_Connected)
            {
                MessageBox.Show("Connect SQL Sucessfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Can't Connect SQL !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timerSetting_Tick(object sender, EventArgs e)
        {
        }

        private void btnDisconnectSQL_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disconnected SQL successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SQL.Instance().Disconnect();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void txtIPPLC_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

        private void btnSaveSQL_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save information sucessfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.SQLPath = txtSQLPath.Text;
            Properties.Settings.Default.UpdateTime = int.Parse(txtUpdateTime.Text);
            Properties.Settings.Default.Save();
        }
    }
}
