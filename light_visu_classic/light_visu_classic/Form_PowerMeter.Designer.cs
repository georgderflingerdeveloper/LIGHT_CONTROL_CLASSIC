namespace light_visu_classic
{
    partial class Form_PowerMeter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPowerMeter = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxTotalEnergyCount = new System.Windows.Forms.TextBox();
            this.textBoxEnergyCountDay = new System.Windows.Forms.TextBox();
            this.bActualiseData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerPowerDataStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPowerDataEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonCounterPreset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPowerMeter)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPowerMeter
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPowerMeter.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPowerMeter.Legends.Add(legend2);
            this.chartPowerMeter.Location = new System.Drawing.Point(153, 25);
            this.chartPowerMeter.Name = "chartPowerMeter";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPowerMeter.Series.Add(series2);
            this.chartPowerMeter.Size = new System.Drawing.Size(826, 515);
            this.chartPowerMeter.TabIndex = 0;
            // 
            // textBoxTotalEnergyCount
            // 
            this.textBoxTotalEnergyCount.Location = new System.Drawing.Point(10, 52);
            this.textBoxTotalEnergyCount.Name = "textBoxTotalEnergyCount";
            this.textBoxTotalEnergyCount.Size = new System.Drawing.Size(137, 22);
            this.textBoxTotalEnergyCount.TabIndex = 1;
            this.textBoxTotalEnergyCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ETotalEnergyKeyDown);
            // 
            // textBoxEnergyCountDay
            // 
            this.textBoxEnergyCountDay.Location = new System.Drawing.Point(10, 110);
            this.textBoxEnergyCountDay.Name = "textBoxEnergyCountDay";
            this.textBoxEnergyCountDay.Size = new System.Drawing.Size(137, 22);
            this.textBoxEnergyCountDay.TabIndex = 2;
            // 
            // bActualiseData
            // 
            this.bActualiseData.Location = new System.Drawing.Point(10, 486);
            this.bActualiseData.Name = "bActualiseData";
            this.bActualiseData.Size = new System.Drawing.Size(125, 54);
            this.bActualiseData.TabIndex = 4;
            this.bActualiseData.Text = "Daten aktualisieren";
            this.bActualiseData.UseVisualStyleBackColor = true;
            this.bActualiseData.Click += new System.EventHandler(this.bActualiseData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "kwH Gesamt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "kwH Tag";
            // 
            // dateTimePickerPowerDataStart
            // 
            this.dateTimePickerPowerDataStart.Location = new System.Drawing.Point(10, 167);
            this.dateTimePickerPowerDataStart.Name = "dateTimePickerPowerDataStart";
            this.dateTimePickerPowerDataStart.Size = new System.Drawing.Size(137, 22);
            this.dateTimePickerPowerDataStart.TabIndex = 7;
            this.dateTimePickerPowerDataStart.ValueChanged += new System.EventHandler(this.EDateTimePickerValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zeitraum Von";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Zeitraum bis";
            // 
            // dateTimePickerPowerDataEnd
            // 
            this.dateTimePickerPowerDataEnd.Location = new System.Drawing.Point(10, 229);
            this.dateTimePickerPowerDataEnd.Name = "dateTimePickerPowerDataEnd";
            this.dateTimePickerPowerDataEnd.Size = new System.Drawing.Size(137, 22);
            this.dateTimePickerPowerDataEnd.TabIndex = 10;
            this.dateTimePickerPowerDataEnd.ValueChanged += new System.EventHandler(this.EDateTimePickerEndValueChanged);
            // 
            // buttonCounterPreset
            // 
            this.buttonCounterPreset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCounterPreset.Location = new System.Drawing.Point(10, 416);
            this.buttonCounterPreset.Name = "buttonCounterPreset";
            this.buttonCounterPreset.Size = new System.Drawing.Size(125, 54);
            this.buttonCounterPreset.TabIndex = 12;
            this.buttonCounterPreset.Text = "Zählerdaten setzen";
            this.buttonCounterPreset.UseVisualStyleBackColor = true;
            this.buttonCounterPreset.Click += new System.EventHandler(this.buttonCounterPreset_Click);
            // 
            // Form_PowerMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 568);
            this.Controls.Add(this.buttonCounterPreset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerPowerDataEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerPowerDataStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bActualiseData);
            this.Controls.Add(this.textBoxEnergyCountDay);
            this.Controls.Add(this.textBoxTotalEnergyCount);
            this.Controls.Add(this.chartPowerMeter);
            this.Name = "Form_PowerMeter";
            ((System.ComponentModel.ISupportInitialize)(this.chartPowerMeter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPowerMeter;
        private System.Windows.Forms.TextBox textBoxTotalEnergyCount;
        private System.Windows.Forms.TextBox textBoxEnergyCountDay;
        private System.Windows.Forms.Button bActualiseData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerPowerDataStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPowerDataEnd;
        private System.Windows.Forms.Button buttonCounterPreset;
    }
}