using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;

namespace SCADA_APP
{
    public partial class frReport : Form
    {
        public frReport()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            btnAlarm.Checked = true;
            btnBox.Checked = false;
            btnTomato.Checked = false;
            SQL.Instance().Show_Alarm();
            dgvData.DataSource = SQL.Instance().dt_alarm;
            SQL.Instance().dt_data.Clear();
            SQL.Instance().dt_boxdata.Clear();
        }

        int red = PLCRead.Instance().Quanity_Red;
        int orange = PLCRead.Instance().Quanity_Orange;
        int green = PLCRead.Instance().Quanity_Green;
        int error = PLCRead.Instance().Quanity_Error;
        private void btnTomato_Click(object sender, EventArgs e)
        {
            btnTomato.Checked = true;
            btnAlarm.Checked = false;
            btnBox.Checked = false;
            SQL.Instance().Show_Data();
            dgvData.DataSource = SQL.Instance().dt_data;
            SQL.Instance().dt_alarm.Clear();
            SQL.Instance().dt_boxdata.Clear();

            //Pie Chart
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Normal Tomato",
                    Values = new ChartValues<double> {red+orange+green},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Error Tomato",
                    Values = new ChartValues<double> {error},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart2.Series = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Type 1",
                    Values = new ChartValues<double> {red},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Type 2",
                    Values = new ChartValues<double> {orange},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Type 3",
                    Values = new ChartValues<double> {green},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Type 4",
                    Values = new ChartValues<double> {error},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
            pieChart2.LegendLocation = LegendLocation.Bottom;

            //Cartesian Chart
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new RowSeries
                {
                    Title = "Type 1",
                    Values = new ChartValues<double> {red},
                    DataLabels = true,
                    RowPadding = 15,
                },
                new RowSeries
                {
                    Title = "Type 2",
                    Values = new ChartValues<double> {orange},
                    DataLabels = true,
                    RowPadding = 15,
                },

                   new RowSeries
                {
                   Title = "Type 3",
                   Values = new ChartValues<double> {green},
                   DataLabels = true,
                   RowPadding = 15,
                },

                   new RowSeries
                {
                   Title = "Type 4",
                   Values = new ChartValues<double> {error},
                   DataLabels = true,
                   RowPadding = 15,
                },

            };

            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        int box1 = PLCRead.Instance().Quanity_Box1;
        int box2 = PLCRead.Instance().Quanity_Box2;
        int box3 = PLCRead.Instance().Quanity_Box3;
        int box4 = PLCRead.Instance().Quanity_Box4;
        private void btnBox_Click(object sender, EventArgs e)
        {
            btnBox.Checked = true;
            btnAlarm.Checked = false;
            btnTomato.Checked = false;
            SQL.Instance().Show_BoxData();
            dgvData.DataSource = SQL.Instance().dt_boxdata;
            SQL.Instance().dt_alarm.Clear();
            SQL.Instance().dt_data.Clear();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Normal Box",
                    Values = new ChartValues<double> {box1+box2+box3},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Error Box",
                    Values = new ChartValues<double> {box4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart2.Series = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Box 1",
                    Values = new ChartValues<double> {box1},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Box 2",
                    Values = new ChartValues<double> {box2},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Box 3",
                    Values = new ChartValues<double> {box3},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Box 4",
                    Values = new ChartValues<double> {box4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
            pieChart2.LegendLocation = LegendLocation.Bottom;

            //Cartesian Chart
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new RowSeries
                {
                    Title = "Box 1",
                    Values = new ChartValues<double> {box1},
                    DataLabels = true,
                    RowPadding = 15,
                },
                new RowSeries
                {
                    Title = "Box 2",
                    Values = new ChartValues<double> {box2},
                    DataLabels = true,
                    RowPadding = 15,
                },

                   new RowSeries
                {
                    Title = "Box 3",
                    Values = new ChartValues<double> {box3},
                    DataLabels = true,
                    RowPadding = 15,
                },

                   new RowSeries
                {
                   Title = "Box 4",
                   Values = new ChartValues<double> {box4},
                   DataLabels = true,
                   RowPadding = 15,
                },
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            SQL.Instance().dt_data.Clear();
            SQL.Instance().dt_boxdata.Clear();
            SQL.Instance().dt_data.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnTomato.Checked)
            {
                if (radioBtn1.Checked)
                {
                    SQL.Instance().Query_Data_Date(dtPicker1.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_data;
                    dtPicker2.Enabled = false;
                }
                if (radioBtn2.Checked)
                {
                    SQL.Instance().Query_Data(dtPicker1.Value.Date, dtPicker2.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_data;
                }
            }

            if (btnBox.Checked)
            {
                if (radioBtn1.Checked)
                {
                    SQL.Instance().Query_BoxData_Date(dtPicker1.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_boxdata;
                    dtPicker2.Enabled = false;
                }
                if (radioBtn2.Checked)
                {
                    SQL.Instance().Query_BoxData(dtPicker1.Value.Date, dtPicker2.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_boxdata;
                }
            }

            if (btnAlarm.Checked)
            {
                if (radioBtn1.Checked)
                {
                    SQL.Instance().Query_Alarm_Date(dtPicker1.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_alarm;
                    dtPicker2.Enabled = false;
                }
                if (radioBtn2.Checked)
                {
                    SQL.Instance().Query_Alarm(dtPicker1.Value.Date, dtPicker2.Value.Date);
                    dgvData.DataSource = SQL.Instance().dt_alarm;
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnAlarm.Checked)
            {
                SQL.Instance().Delete_Alarm();
            }

            if (btnTomato.Checked)
            {
                SQL.Instance().Delete_Data();
            }

            if (btnBox.Checked)
            {
                SQL.Instance().Delete_BoxData();
            }
        }

        private void radioBtn1_Click(object sender, EventArgs e)
        {
            dtPicker2.Enabled = false;
        }

        private void radioBtn2_Click(object sender, EventArgs e)
        {
            dtPicker2.Enabled = true;
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            if (btnTomato.Checked)
            {
                SQL.Instance().dt_data.Clear();
            }
            if (btnBox.Checked)
            {
                SQL.Instance().dt_boxdata.Clear();
            }
            if (btnAlarm.Checked)
            {
                SQL.Instance().dt_alarm.Clear();
            }
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            if (btnTomato.Checked)
            {
                SQL.Instance().Show_Data();
            }

            if (btnBox.Checked)
            {
                SQL.Instance().Show_BoxData();
            }
            if (btnAlarm.Checked)
            {
                SQL.Instance().Show_Alarm();
            }
        }

        private void ToExcel(DataGridView dgv, string filename)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "Xuat du lieu";

                //export header
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }
                // export content 
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save workbook
                workbook.SaveAs(filename);
                workbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        public void exportgridtopdf(DataGridView dgw, string filename)
        {

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgvData.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;



            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            //Add Header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            //Add DataRow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var savefile = new SaveFileDialog();
            savefile.FileName = filename;
            savefile.DefaultExt = ".pdf";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }


        private void btnReportExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvData, saveFileDialog1.FileName);
            }
        }

        private void btnReportPdf_Click_1(object sender, EventArgs e)
        {
            exportgridtopdf(dgvData, "fhf");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
