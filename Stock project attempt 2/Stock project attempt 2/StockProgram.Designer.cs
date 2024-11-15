namespace Stock_project_attempt_2
{
    partial class StockProgram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_stockLoad = new System.Windows.Forms.Button();
            this.openFileDialog_stockChoose = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView_candleSticks = new System.Windows.Forms.DataGridView();
            this.chart_OHLC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButton_day = new System.Windows.Forms.RadioButton();
            this.radioButton_week = new System.Windows.Forms.RadioButton();
            this.radioButton_month = new System.Windows.Forms.RadioButton();
            this.groupBox_rangeSelect = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.groupBox_datePick = new System.Windows.Forms.GroupBox();
            this.label_endDate = new System.Windows.Forms.Label();
            this.label_startDate = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_candleSticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLC)).BeginInit();
            this.groupBox_rangeSelect.SuspendLayout();
            this.groupBox_datePick.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_stockLoad
            // 
            this.button_stockLoad.Location = new System.Drawing.Point(684, 12);
            this.button_stockLoad.Name = "button_stockLoad";
            this.button_stockLoad.Size = new System.Drawing.Size(96, 39);
            this.button_stockLoad.TabIndex = 0;
            this.button_stockLoad.Text = "Please select a stock";
            this.button_stockLoad.UseVisualStyleBackColor = true;
            this.button_stockLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog_stockChoose
            // 
            this.openFileDialog_stockChoose.Filter = "All Files|*.csv|Monthly|*-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv";
            this.openFileDialog_stockChoose.InitialDirectory = "C:\\Users\\Owner\\OneDrive\\Documents\\The place I cram all my hw lol\\COP\\Stock Data";
            this.openFileDialog_stockChoose.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dataGridView_candleSticks
            // 
            this.dataGridView_candleSticks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_candleSticks.Location = new System.Drawing.Point(13, 57);
            this.dataGridView_candleSticks.Name = "dataGridView_candleSticks";
            this.dataGridView_candleSticks.Size = new System.Drawing.Size(656, 137);
            this.dataGridView_candleSticks.TabIndex = 1;
            // 
            // chart_OHLC
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_volume";
            this.chart_OHLC.ChartAreas.Add(chartArea1);
            this.chart_OHLC.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend_OHLC";
            this.chart_OHLC.Legends.Add(legend1);
            this.chart_OHLC.Location = new System.Drawing.Point(-3, 200);
            this.chart_OHLC.Name = "chart_OHLC";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.Legend = "Legend_OHLC";
            series1.Name = "OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "high,low,open,close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_volume";
            series2.Legend = "Legend_OHLC";
            series2.Name = "Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            this.chart_OHLC.Series.Add(series1);
            this.chart_OHLC.Series.Add(series2);
            this.chart_OHLC.Size = new System.Drawing.Size(803, 239);
            this.chart_OHLC.TabIndex = 2;
            this.chart_OHLC.Text = "chart_OHLC";
            // 
            // radioButton_day
            // 
            this.radioButton_day.AutoSize = true;
            this.radioButton_day.Location = new System.Drawing.Point(16, 19);
            this.radioButton_day.Name = "radioButton_day";
            this.radioButton_day.Size = new System.Drawing.Size(44, 17);
            this.radioButton_day.TabIndex = 3;
            this.radioButton_day.TabStop = true;
            this.radioButton_day.Text = "Day";
            this.radioButton_day.UseVisualStyleBackColor = true;
            this.radioButton_day.CheckedChanged += new System.EventHandler(this.radioButton_day_CheckedChanged);
            // 
            // radioButton_week
            // 
            this.radioButton_week.AutoSize = true;
            this.radioButton_week.Location = new System.Drawing.Point(16, 42);
            this.radioButton_week.Name = "radioButton_week";
            this.radioButton_week.Size = new System.Drawing.Size(54, 17);
            this.radioButton_week.TabIndex = 4;
            this.radioButton_week.TabStop = true;
            this.radioButton_week.Text = "Week";
            this.radioButton_week.UseVisualStyleBackColor = true;
            // 
            // radioButton_month
            // 
            this.radioButton_month.AutoSize = true;
            this.radioButton_month.Location = new System.Drawing.Point(16, 65);
            this.radioButton_month.Name = "radioButton_month";
            this.radioButton_month.Size = new System.Drawing.Size(55, 17);
            this.radioButton_month.TabIndex = 5;
            this.radioButton_month.TabStop = true;
            this.radioButton_month.Text = "Month";
            this.radioButton_month.UseVisualStyleBackColor = true;
            // 
            // groupBox_rangeSelect
            // 
            this.groupBox_rangeSelect.Controls.Add(this.radioButton_day);
            this.groupBox_rangeSelect.Controls.Add(this.radioButton_month);
            this.groupBox_rangeSelect.Controls.Add(this.radioButton_week);
            this.groupBox_rangeSelect.Location = new System.Drawing.Point(684, 82);
            this.groupBox_rangeSelect.Name = "groupBox_rangeSelect";
            this.groupBox_rangeSelect.Size = new System.Drawing.Size(96, 112);
            this.groupBox_rangeSelect.TabIndex = 6;
            this.groupBox_rangeSelect.TabStop = false;
            this.groupBox_rangeSelect.Text = "Range select:";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(68, 19);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(221, 20);
            this.dateTimePicker_start.TabIndex = 7;
            this.dateTimePicker_start.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(365, 19);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(221, 20);
            this.dateTimePicker_End.TabIndex = 8;
            this.dateTimePicker_End.Value = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            // 
            // groupBox_datePick
            // 
            this.groupBox_datePick.Controls.Add(this.label_endDate);
            this.groupBox_datePick.Controls.Add(this.label_startDate);
            this.groupBox_datePick.Controls.Add(this.dateTimePicker_start);
            this.groupBox_datePick.Controls.Add(this.dateTimePicker_End);
            this.groupBox_datePick.Location = new System.Drawing.Point(12, 1);
            this.groupBox_datePick.Name = "groupBox_datePick";
            this.groupBox_datePick.Size = new System.Drawing.Size(657, 50);
            this.groupBox_datePick.TabIndex = 9;
            this.groupBox_datePick.TabStop = false;
            this.groupBox_datePick.Text = "Date selection:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(306, 19);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(53, 13);
            this.label_endDate.TabIndex = 10;
            this.label_endDate.Text = "End date:";
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(6, 19);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(56, 13);
            this.label_startDate.TabIndex = 9;
            this.label_startDate.Text = "Start date:";
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(684, 53);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(96, 23);
            this.button_update.TabIndex = 10;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // StockProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.groupBox_datePick);
            this.Controls.Add(this.groupBox_rangeSelect);
            this.Controls.Add(this.chart_OHLC);
            this.Controls.Add(this.dataGridView_candleSticks);
            this.Controls.Add(this.button_stockLoad);
            this.Name = "StockProgram";
            this.Text = "Stock Program";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_candleSticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLC)).EndInit();
            this.groupBox_rangeSelect.ResumeLayout(false);
            this.groupBox_rangeSelect.PerformLayout();
            this.groupBox_datePick.ResumeLayout(false);
            this.groupBox_datePick.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_stockLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockChoose;
        private System.Windows.Forms.DataGridView dataGridView_candleSticks;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLC;
        private System.Windows.Forms.RadioButton radioButton_day;
        private System.Windows.Forms.RadioButton radioButton_week;
        private System.Windows.Forms.RadioButton radioButton_month;
        private System.Windows.Forms.GroupBox groupBox_rangeSelect;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.GroupBox groupBox_datePick;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Button button_update;
    }
}

