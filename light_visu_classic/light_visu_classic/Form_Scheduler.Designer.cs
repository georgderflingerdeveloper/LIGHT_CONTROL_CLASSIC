namespace light_visu_classic
{
    partial class Form_Scheduler
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
            if( disposing && ( components != null ) )
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
            this.numericUpDownHourSelector = new System.Windows.Forms.NumericUpDown();
            this.lbHour = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.numericUpDownMinuteSelector = new System.Windows.Forms.NumericUpDown();
            this.lbSecond = new System.Windows.Forms.Label();
            this.numericUpDownSecondSelector = new System.Windows.Forms.NumericUpDown();
            this.bAddScheduleJob = new System.Windows.Forms.Button();
            this.bNextScheduleJob = new System.Windows.Forms.Button();
            this.bPreviousScheduleJob = new System.Windows.Forms.Button();
            this.bRemoveScheduleJob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.cbDaily = new System.Windows.Forms.CheckBox();
            this.cbMon = new System.Windows.Forms.CheckBox();
            this.cbTue = new System.Windows.Forms.CheckBox();
            this.cbWed = new System.Windows.Forms.CheckBox();
            this.cbThu = new System.Windows.Forms.CheckBox();
            this.cbFr = new System.Windows.Forms.CheckBox();
            this.cbSat = new System.Windows.Forms.CheckBox();
            this.cbSun = new System.Windows.Forms.CheckBox();
            this.bStartScheduler = new System.Windows.Forms.Button();
            this.lbStartStop = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.bStopScheduler = new System.Windows.Forms.Button();
            this.pictureBoxShowSchedulerStatus = new System.Windows.Forms.PictureBox();
            this.bDummyH = new System.Windows.Forms.Button();
            this.bDummyM = new System.Windows.Forms.Button();
            this.bDummyS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHourSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinuteSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowSchedulerStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownHourSelector
            // 
            this.numericUpDownHourSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDownHourSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHourSelector.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownHourSelector.Location = new System.Drawing.Point(34, 70);
            this.numericUpDownHourSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownHourSelector.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownHourSelector.Name = "numericUpDownHourSelector";
            this.numericUpDownHourSelector.Size = new System.Drawing.Size(68, 46);
            this.numericUpDownHourSelector.TabIndex = 0;
            this.numericUpDownHourSelector.ValueChanged += new System.EventHandler(this.SetTime);
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbHour.Location = new System.Drawing.Point(42, 2);
            this.lbHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(46, 42);
            this.lbHour.TabIndex = 1;
            this.lbHour.Text = "H";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbMinute.Location = new System.Drawing.Point(130, 2);
            this.lbMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(50, 42);
            this.lbMinute.TabIndex = 3;
            this.lbMinute.Text = "M";
            // 
            // numericUpDownMinuteSelector
            // 
            this.numericUpDownMinuteSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDownMinuteSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMinuteSelector.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownMinuteSelector.Location = new System.Drawing.Point(128, 70);
            this.numericUpDownMinuteSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownMinuteSelector.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownMinuteSelector.Name = "numericUpDownMinuteSelector";
            this.numericUpDownMinuteSelector.Size = new System.Drawing.Size(68, 46);
            this.numericUpDownMinuteSelector.TabIndex = 2;
            this.numericUpDownMinuteSelector.ValueChanged += new System.EventHandler(this.SetTime);
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbSecond.Location = new System.Drawing.Point(221, 2);
            this.lbSecond.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(44, 42);
            this.lbSecond.TabIndex = 5;
            this.lbSecond.Text = "S";
            // 
            // numericUpDownSecondSelector
            // 
            this.numericUpDownSecondSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDownSecondSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSecondSelector.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownSecondSelector.Location = new System.Drawing.Point(215, 68);
            this.numericUpDownSecondSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownSecondSelector.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownSecondSelector.Name = "numericUpDownSecondSelector";
            this.numericUpDownSecondSelector.Size = new System.Drawing.Size(68, 46);
            this.numericUpDownSecondSelector.TabIndex = 4;
            this.numericUpDownSecondSelector.ValueChanged += new System.EventHandler(this.SetTime);
            // 
            // bAddScheduleJob
            // 
            this.bAddScheduleJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddScheduleJob.Location = new System.Drawing.Point(28, 145);
            this.bAddScheduleJob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAddScheduleJob.Name = "bAddScheduleJob";
            this.bAddScheduleJob.Size = new System.Drawing.Size(96, 71);
            this.bAddScheduleJob.TabIndex = 6;
            this.bAddScheduleJob.Text = "+";
            this.bAddScheduleJob.UseVisualStyleBackColor = true;
            this.bAddScheduleJob.Click += new System.EventHandler(this.bAddScheduleJob_Click);
            // 
            // bNextScheduleJob
            // 
            this.bNextScheduleJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNextScheduleJob.Location = new System.Drawing.Point(435, 50);
            this.bNextScheduleJob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bNextScheduleJob.Name = "bNextScheduleJob";
            this.bNextScheduleJob.Size = new System.Drawing.Size(69, 92);
            this.bNextScheduleJob.TabIndex = 7;
            this.bNextScheduleJob.Text = ">";
            this.bNextScheduleJob.UseVisualStyleBackColor = true;
            this.bNextScheduleJob.Click += new System.EventHandler(this.bNextScheduleJob_Click);
            // 
            // bPreviousScheduleJob
            // 
            this.bPreviousScheduleJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bPreviousScheduleJob.Location = new System.Drawing.Point(349, 50);
            this.bPreviousScheduleJob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bPreviousScheduleJob.Name = "bPreviousScheduleJob";
            this.bPreviousScheduleJob.Size = new System.Drawing.Size(69, 92);
            this.bPreviousScheduleJob.TabIndex = 8;
            this.bPreviousScheduleJob.Text = "<";
            this.bPreviousScheduleJob.UseVisualStyleBackColor = true;
            this.bPreviousScheduleJob.Click += new System.EventHandler(this.bPreviousScheduleJob_Click);
            // 
            // bRemoveScheduleJob
            // 
            this.bRemoveScheduleJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRemoveScheduleJob.Location = new System.Drawing.Point(28, 259);
            this.bRemoveScheduleJob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bRemoveScheduleJob.Name = "bRemoveScheduleJob";
            this.bRemoveScheduleJob.Size = new System.Drawing.Size(96, 71);
            this.bRemoveScheduleJob.TabIndex = 9;
            this.bRemoveScheduleJob.Text = "-";
            this.bRemoveScheduleJob.UseVisualStyleBackColor = true;
            this.bRemoveScheduleJob.Click += new System.EventHandler(this.bRemoveScheduleJob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(398, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Number";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.ForeColor = System.Drawing.Color.Blue;
            this.lbNumber.Location = new System.Drawing.Point(416, 25);
            this.lbNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(18, 20);
            this.lbNumber.TabIndex = 11;
            this.lbNumber.Text = "1";
            // 
            // cbDaily
            // 
            this.cbDaily.AutoSize = true;
            this.cbDaily.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDaily.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbDaily.Location = new System.Drawing.Point(249, 275);
            this.cbDaily.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDaily.Name = "cbDaily";
            this.cbDaily.Size = new System.Drawing.Size(150, 43);
            this.cbDaily.TabIndex = 12;
            this.cbDaily.Text = "Täglich";
            this.cbDaily.UseVisualStyleBackColor = true;
            this.cbDaily.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbMon
            // 
            this.cbMon.AutoSize = true;
            this.cbMon.BackColor = System.Drawing.SystemColors.Control;
            this.cbMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbMon.Location = new System.Drawing.Point(146, 172);
            this.cbMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(105, 43);
            this.cbMon.TabIndex = 13;
            this.cbMon.Text = "Mon";
            this.cbMon.UseVisualStyleBackColor = false;
            this.cbMon.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbTue
            // 
            this.cbTue.AutoSize = true;
            this.cbTue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbTue.Location = new System.Drawing.Point(249, 172);
            this.cbTue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTue.Name = "cbTue";
            this.cbTue.Size = new System.Drawing.Size(72, 43);
            this.cbTue.TabIndex = 14;
            this.cbTue.Text = "Di";
            this.cbTue.UseVisualStyleBackColor = true;
            this.cbTue.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbWed
            // 
            this.cbWed.AutoSize = true;
            this.cbWed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbWed.Location = new System.Drawing.Point(332, 172);
            this.cbWed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWed.Name = "cbWed";
            this.cbWed.Size = new System.Drawing.Size(75, 43);
            this.cbWed.TabIndex = 15;
            this.cbWed.Text = "Mi";
            this.cbWed.UseVisualStyleBackColor = true;
            this.cbWed.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbThu
            // 
            this.cbThu.AutoSize = true;
            this.cbThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbThu.Location = new System.Drawing.Point(146, 224);
            this.cbThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbThu.Name = "cbThu";
            this.cbThu.Size = new System.Drawing.Size(83, 43);
            this.cbThu.TabIndex = 16;
            this.cbThu.Text = "Do";
            this.cbThu.UseVisualStyleBackColor = true;
            this.cbThu.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbFr
            // 
            this.cbFr.AutoSize = true;
            this.cbFr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbFr.Location = new System.Drawing.Point(249, 224);
            this.cbFr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFr.Name = "cbFr";
            this.cbFr.Size = new System.Drawing.Size(71, 43);
            this.cbFr.TabIndex = 17;
            this.cbFr.Text = "Fr";
            this.cbFr.UseVisualStyleBackColor = true;
            this.cbFr.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbSat
            // 
            this.cbSat.AutoSize = true;
            this.cbSat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbSat.Location = new System.Drawing.Point(332, 224);
            this.cbSat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSat.Name = "cbSat";
            this.cbSat.Size = new System.Drawing.Size(81, 43);
            this.cbSat.TabIndex = 18;
            this.cbSat.Text = "Sa";
            this.cbSat.UseVisualStyleBackColor = true;
            this.cbSat.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // cbSun
            // 
            this.cbSun.AutoSize = true;
            this.cbSun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbSun.Location = new System.Drawing.Point(146, 275);
            this.cbSun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSun.Name = "cbSun";
            this.cbSun.Size = new System.Drawing.Size(100, 43);
            this.cbSun.TabIndex = 19;
            this.cbSun.Text = "Son";
            this.cbSun.UseVisualStyleBackColor = true;
            this.cbSun.CheckedChanged += new System.EventHandler(this.EDaysChanged);
            // 
            // bStartScheduler
            // 
            this.bStartScheduler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bStartScheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bStartScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStartScheduler.Location = new System.Drawing.Point(28, 349);
            this.bStartScheduler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bStartScheduler.Name = "bStartScheduler";
            this.bStartScheduler.Size = new System.Drawing.Size(196, 119);
            this.bStartScheduler.TabIndex = 21;
            this.bStartScheduler.Text = "Start";
            this.bStartScheduler.UseVisualStyleBackColor = true;
            this.bStartScheduler.Click += new System.EventHandler(this.bStartScheduler_Click);
            // 
            // lbStartStop
            // 
            this.lbStartStop.AutoSize = true;
            this.lbStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbStartStop.Location = new System.Drawing.Point(178, 145);
            this.lbStartStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStartStop.Name = "lbStartStop";
            this.lbStartStop.Size = new System.Drawing.Size(158, 20);
            this.lbStartStop.TabIndex = 22;
            this.lbStartStop.Text = "StartTime/StopTime";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTime.Location = new System.Drawing.Point(389, 145);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(73, 20);
            this.lbTime.TabIndex = 23;
            this.lbTime.Text = "00:00:00";
            // 
            // bStopScheduler
            // 
            this.bStopScheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bStopScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStopScheduler.Location = new System.Drawing.Point(308, 349);
            this.bStopScheduler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bStopScheduler.Name = "bStopScheduler";
            this.bStopScheduler.Size = new System.Drawing.Size(196, 119);
            this.bStopScheduler.TabIndex = 24;
            this.bStopScheduler.Text = "Stop";
            this.bStopScheduler.UseVisualStyleBackColor = true;
            this.bStopScheduler.Click += new System.EventHandler(this.bStopScheduler_Click);
            // 
            // pictureBoxShowSchedulerStatus
            // 
            this.pictureBoxShowSchedulerStatus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxShowSchedulerStatus.Location = new System.Drawing.Point(410, 188);
            this.pictureBoxShowSchedulerStatus.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxShowSchedulerStatus.Name = "pictureBoxShowSchedulerStatus";
            this.pictureBoxShowSchedulerStatus.Size = new System.Drawing.Size(118, 118);
            this.pictureBoxShowSchedulerStatus.TabIndex = 25;
            this.pictureBoxShowSchedulerStatus.TabStop = false;
            // 
            // bDummyH
            // 
            this.bDummyH.Location = new System.Drawing.Point(19, 52);
            this.bDummyH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bDummyH.Name = "bDummyH";
            this.bDummyH.Size = new System.Drawing.Size(94, 82);
            this.bDummyH.TabIndex = 26;
            this.bDummyH.UseVisualStyleBackColor = true;
            this.bDummyH.MouseEnter += new System.EventHandler(this.ShapeMouseEnter);
            // 
            // bDummyM
            // 
            this.bDummyM.Location = new System.Drawing.Point(112, 52);
            this.bDummyM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bDummyM.Name = "bDummyM";
            this.bDummyM.Size = new System.Drawing.Size(94, 82);
            this.bDummyM.TabIndex = 27;
            this.bDummyM.UseVisualStyleBackColor = true;
            this.bDummyM.MouseEnter += new System.EventHandler(this.ShapeMouseEnter);
            // 
            // bDummyS
            // 
            this.bDummyS.Location = new System.Drawing.Point(206, 52);
            this.bDummyS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bDummyS.Name = "bDummyS";
            this.bDummyS.Size = new System.Drawing.Size(94, 82);
            this.bDummyS.TabIndex = 28;
            this.bDummyS.UseVisualStyleBackColor = true;
            this.bDummyS.MouseEnter += new System.EventHandler(this.ShapeMouseEnter);
            // 
            // Form_Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(554, 502);
            this.Controls.Add(this.numericUpDownSecondSelector);
            this.Controls.Add(this.bDummyS);
            this.Controls.Add(this.numericUpDownMinuteSelector);
            this.Controls.Add(this.bDummyM);
            this.Controls.Add(this.numericUpDownHourSelector);
            this.Controls.Add(this.bDummyH);
            this.Controls.Add(this.pictureBoxShowSchedulerStatus);
            this.Controls.Add(this.bStopScheduler);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbStartStop);
            this.Controls.Add(this.bStartScheduler);
            this.Controls.Add(this.cbSun);
            this.Controls.Add(this.cbSat);
            this.Controls.Add(this.cbFr);
            this.Controls.Add(this.cbThu);
            this.Controls.Add(this.cbWed);
            this.Controls.Add(this.cbTue);
            this.Controls.Add(this.cbMon);
            this.Controls.Add(this.cbDaily);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bRemoveScheduleJob);
            this.Controls.Add(this.bPreviousScheduleJob);
            this.Controls.Add(this.bNextScheduleJob);
            this.Controls.Add(this.bAddScheduleJob);
            this.Controls.Add(this.lbSecond);
            this.Controls.Add(this.lbMinute);
            this.Controls.Add(this.lbHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(560, 528);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 528);
            this.Name = "Form_Scheduler";
            this.Text = "Scheduler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SchedClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHourSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinuteSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowSchedulerStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownHourSelector;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.NumericUpDown numericUpDownMinuteSelector;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.NumericUpDown numericUpDownSecondSelector;
        private System.Windows.Forms.Button bAddScheduleJob;
        private System.Windows.Forms.Button bNextScheduleJob;
        private System.Windows.Forms.Button bPreviousScheduleJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.CheckBox cbDaily;
        private System.Windows.Forms.CheckBox cbMon;
        private System.Windows.Forms.CheckBox cbTue;
        private System.Windows.Forms.CheckBox cbWed;
        private System.Windows.Forms.CheckBox cbThu;
        private System.Windows.Forms.CheckBox cbFr;
        private System.Windows.Forms.CheckBox cbSat;
        private System.Windows.Forms.CheckBox cbSun;
        private System.Windows.Forms.Button bStartScheduler;
        private System.Windows.Forms.Label lbStartStop;
        private System.Windows.Forms.Button bRemoveScheduleJob;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button bStopScheduler;
        private System.Windows.Forms.PictureBox pictureBoxShowSchedulerStatus;
        private System.Windows.Forms.Button bDummyH;
        private System.Windows.Forms.Button bDummyM;
        private System.Windows.Forms.Button bDummyS;
    }
}