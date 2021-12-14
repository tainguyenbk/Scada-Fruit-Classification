
namespace SCADA_APP
{
    partial class frReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.btnReportPdf = new System.Windows.Forms.Button();
            this.btnReportExcel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.fiveCodPanelShadow3 = new FiveCodMaterialDesign.FiveCodPanelShadow();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPicker2 = new System.Windows.Forms.DateTimePicker();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBtn2 = new System.Windows.Forms.RadioButton();
            this.radioBtn1 = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fiveCodCardGradient3 = new FiveCodMaterialDesign.FiveCodCardGradient();
            this.btnTomato = new FiveCodMaterialDesign.FiveCodCheckBox();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.fiveCodPanelShadow2 = new FiveCodMaterialDesign.FiveCodPanelShadow();
            this.btnAlarm = new FiveCodMaterialDesign.FiveCodCheckBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.fiveCodPanelShadow1 = new FiveCodMaterialDesign.FiveCodPanelShadow();
            this.fiveCodCardGradient2 = new FiveCodMaterialDesign.FiveCodCardGradient();
            this.fiveCodCardGradient1 = new FiveCodMaterialDesign.FiveCodCardGradient();
            this.btnBox = new FiveCodMaterialDesign.FiveCodCheckBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
            this.cartesianChart1.Location = new System.Drawing.Point(709, 129);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(615, 198);
            this.cartesianChart1.TabIndex = 75;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // btnReportPdf
            // 
            this.btnReportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnReportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnReportPdf.Image = global::SCADA_APP.Properties.Resources.pdf_45px;
            this.btnReportPdf.Location = new System.Drawing.Point(72, 21);
            this.btnReportPdf.Name = "btnReportPdf";
            this.btnReportPdf.Size = new System.Drawing.Size(50, 50);
            this.btnReportPdf.TabIndex = 61;
            this.btnReportPdf.UseVisualStyleBackColor = false;
            this.btnReportPdf.Click += new System.EventHandler(this.btnReportPdf_Click_1);
            // 
            // btnReportExcel
            // 
            this.btnReportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnReportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnReportExcel.Image = global::SCADA_APP.Properties.Resources.microsoft_excel_2019_50px;
            this.btnReportExcel.Location = new System.Drawing.Point(16, 21);
            this.btnReportExcel.Name = "btnReportExcel";
            this.btnReportExcel.Size = new System.Drawing.Size(50, 50);
            this.btnReportExcel.TabIndex = 60;
            this.btnReportExcel.UseVisualStyleBackColor = false;
            this.btnReportExcel.Click += new System.EventHandler(this.btnReportExcel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.groupBox4.Controls.Add(this.btnReportPdf);
            this.groupBox4.Controls.Add(this.btnReportExcel);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(693, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 87);
            this.groupBox4.TabIndex = 74;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Report";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.btnExit.Image = global::SCADA_APP.Properties.Resources.previous;
            this.btnExit.Location = new System.Drawing.Point(591, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 41;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(10, 99);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowHeadersWidth = 30;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.Size = new System.Drawing.Size(669, 388);
            this.dgvData.TabIndex = 73;
            // 
            // fiveCodPanelShadow3
            // 
            this.fiveCodPanelShadow3.BorderColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow3.Location = new System.Drawing.Point(693, 99);
            this.fiveCodPanelShadow3.Name = "fiveCodPanelShadow3";
            this.fiveCodPanelShadow3.PanelColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow3.Size = new System.Drawing.Size(659, 258);
            this.fiveCodPanelShadow3.TabIndex = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(9, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 160);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Panel";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtPicker2);
            this.groupBox3.Controls.Add(this.dtPicker1);
            this.groupBox3.Location = new System.Drawing.Point(185, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 122);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "End day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Begin day";
            // 
            // dtPicker2
            // 
            this.dtPicker2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker2.Location = new System.Drawing.Point(93, 68);
            this.dtPicker2.Name = "dtPicker2";
            this.dtPicker2.Size = new System.Drawing.Size(191, 25);
            this.dtPicker2.TabIndex = 0;
            // 
            // dtPicker1
            // 
            this.dtPicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker1.Location = new System.Drawing.Point(93, 27);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.Size = new System.Drawing.Size(191, 25);
            this.dtPicker1.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(168)))), ((int)(((byte)(227)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(539, 113);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 33);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(168)))), ((int)(((byte)(227)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(539, 68);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 33);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(168)))), ((int)(((byte)(227)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(539, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 33);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.radioBtn2);
            this.groupBox2.Controls.Add(this.radioBtn1);
            this.groupBox2.Location = new System.Drawing.Point(12, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // radioBtn2
            // 
            this.radioBtn2.AutoSize = true;
            this.radioBtn2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn2.ForeColor = System.Drawing.Color.Black;
            this.radioBtn2.Location = new System.Drawing.Point(6, 72);
            this.radioBtn2.Name = "radioBtn2";
            this.radioBtn2.Size = new System.Drawing.Size(137, 21);
            this.radioBtn2.TabIndex = 3;
            this.radioBtn2.TabStop = true;
            this.radioBtn2.Text = "Watch several days";
            this.radioBtn2.UseVisualStyleBackColor = true;
            this.radioBtn2.Click += new System.EventHandler(this.radioBtn2_Click);
            // 
            // radioBtn1
            // 
            this.radioBtn1.AutoSize = true;
            this.radioBtn1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn1.ForeColor = System.Drawing.Color.Black;
            this.radioBtn1.Location = new System.Drawing.Point(6, 33);
            this.radioBtn1.Name = "radioBtn1";
            this.radioBtn1.Size = new System.Drawing.Size(97, 21);
            this.radioBtn1.TabIndex = 2;
            this.radioBtn1.TabStop = true;
            this.radioBtn1.Text = "Watch 1 day";
            this.radioBtn1.UseVisualStyleBackColor = true;
            this.radioBtn1.Click += new System.EventHandler(this.radioBtn1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xlsx";
            // 
            // fiveCodCardGradient3
            // 
            this.fiveCodCardGradient3.BackColor = System.Drawing.Color.Transparent;
            this.fiveCodCardGradient3.FiveCodColorEsquina1 = System.Drawing.Color.DarkViolet;
            this.fiveCodCardGradient3.FiveCodColorEsquina2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(237)))));
            this.fiveCodCardGradient3.FiveCodTitulo = "       View Box";
            this.fiveCodCardGradient3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveCodCardGradient3.ForeColor = System.Drawing.Color.White;
            this.fiveCodCardGradient3.Location = new System.Drawing.Point(469, 6);
            this.fiveCodCardGradient3.Name = "fiveCodCardGradient3";
            this.fiveCodCardGradient3.Size = new System.Drawing.Size(210, 87);
            this.fiveCodCardGradient3.TabIndex = 70;
            // 
            // btnTomato
            // 
            this.btnTomato.AutoSize = true;
            this.btnTomato.CheckColor = "#508ef5";
            this.btnTomato.Location = new System.Drawing.Point(249, 12);
            this.btnTomato.Name = "btnTomato";
            this.btnTomato.Size = new System.Drawing.Size(20, 20);
            this.btnTomato.TabIndex = 69;
            this.btnTomato.UseVisualStyleBackColor = true;
            this.btnTomato.Click += new System.EventHandler(this.btnTomato_Click);
            // 
            // pieChart2
            // 
            this.pieChart2.BackColor = System.Drawing.Color.White;
            this.pieChart2.Location = new System.Drawing.Point(1039, 399);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(285, 240);
            this.pieChart2.TabIndex = 68;
            this.pieChart2.Text = "pieChart2";
            // 
            // fiveCodPanelShadow2
            // 
            this.fiveCodPanelShadow2.BorderColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow2.Location = new System.Drawing.Point(1027, 363);
            this.fiveCodPanelShadow2.Name = "fiveCodPanelShadow2";
            this.fiveCodPanelShadow2.PanelColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow2.Size = new System.Drawing.Size(325, 290);
            this.fiveCodPanelShadow2.TabIndex = 67;
            // 
            // btnAlarm
            // 
            this.btnAlarm.AutoSize = true;
            this.btnAlarm.CheckColor = "#508ef5";
            this.btnAlarm.Location = new System.Drawing.Point(21, 12);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(20, 20);
            this.btnAlarm.TabIndex = 66;
            this.btnAlarm.UseVisualStyleBackColor = true;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // pieChart1
            // 
            this.pieChart1.BackColor = System.Drawing.Color.White;
            this.pieChart1.Location = new System.Drawing.Point(731, 399);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(240, 240);
            this.pieChart1.TabIndex = 65;
            this.pieChart1.Text = "pieChart1";
            // 
            // fiveCodPanelShadow1
            // 
            this.fiveCodPanelShadow1.BorderColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow1.Location = new System.Drawing.Point(693, 363);
            this.fiveCodPanelShadow1.Name = "fiveCodPanelShadow1";
            this.fiveCodPanelShadow1.PanelColor = System.Drawing.Color.White;
            this.fiveCodPanelShadow1.Size = new System.Drawing.Size(325, 290);
            this.fiveCodPanelShadow1.TabIndex = 64;
            // 
            // fiveCodCardGradient2
            // 
            this.fiveCodCardGradient2.BackColor = System.Drawing.Color.Transparent;
            this.fiveCodCardGradient2.FiveCodColorEsquina1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.fiveCodCardGradient2.FiveCodColorEsquina2 = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(250)))), ((int)(((byte)(67)))));
            this.fiveCodCardGradient2.FiveCodTitulo = "        View Tomato";
            this.fiveCodCardGradient2.ForeColor = System.Drawing.Color.White;
            this.fiveCodCardGradient2.Location = new System.Drawing.Point(238, 6);
            this.fiveCodCardGradient2.Name = "fiveCodCardGradient2";
            this.fiveCodCardGradient2.Size = new System.Drawing.Size(210, 87);
            this.fiveCodCardGradient2.TabIndex = 63;
            this.fiveCodCardGradient2.Text = "fiveCodCardGradient2";
            // 
            // fiveCodCardGradient1
            // 
            this.fiveCodCardGradient1.BackColor = System.Drawing.Color.Transparent;
            this.fiveCodCardGradient1.FiveCodColorEsquina1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.fiveCodCardGradient1.FiveCodColorEsquina2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.fiveCodCardGradient1.FiveCodTitulo = "       View Alarm";
            this.fiveCodCardGradient1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveCodCardGradient1.ForeColor = System.Drawing.Color.White;
            this.fiveCodCardGradient1.Location = new System.Drawing.Point(9, 6);
            this.fiveCodCardGradient1.Name = "fiveCodCardGradient1";
            this.fiveCodCardGradient1.Size = new System.Drawing.Size(210, 87);
            this.fiveCodCardGradient1.TabIndex = 62;
            // 
            // btnBox
            // 
            this.btnBox.AutoSize = true;
            this.btnBox.CheckColor = "#508ef5";
            this.btnBox.Location = new System.Drawing.Point(481, 12);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(20, 20);
            this.btnBox.TabIndex = 76;
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // frReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 658);
            this.Controls.Add(this.btnBox);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.fiveCodPanelShadow3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fiveCodCardGradient3);
            this.Controls.Add(this.btnTomato);
            this.Controls.Add(this.pieChart2);
            this.Controls.Add(this.fiveCodPanelShadow2);
            this.Controls.Add(this.btnAlarm);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.fiveCodPanelShadow1);
            this.Controls.Add(this.fiveCodCardGradient2);
            this.Controls.Add(this.fiveCodCardGradient1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frReport";
            this.Text = "Report";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btnReportPdf;
        private System.Windows.Forms.Button btnReportExcel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvData;
        private FiveCodMaterialDesign.FiveCodPanelShadow fiveCodPanelShadow3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPicker2;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioBtn2;
        private System.Windows.Forms.RadioButton radioBtn1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private FiveCodMaterialDesign.FiveCodCardGradient fiveCodCardGradient3;
        private FiveCodMaterialDesign.FiveCodCheckBox btnTomato;
        private LiveCharts.WinForms.PieChart pieChart2;
        private FiveCodMaterialDesign.FiveCodPanelShadow fiveCodPanelShadow2;
        private FiveCodMaterialDesign.FiveCodCheckBox btnAlarm;
        private LiveCharts.WinForms.PieChart pieChart1;
        private FiveCodMaterialDesign.FiveCodPanelShadow fiveCodPanelShadow1;
        private FiveCodMaterialDesign.FiveCodCardGradient fiveCodCardGradient2;
        private FiveCodMaterialDesign.FiveCodCardGradient fiveCodCardGradient1;
        private FiveCodMaterialDesign.FiveCodCheckBox btnBox;
    }
}