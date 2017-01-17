namespace light_visu_classic
{
    partial class Form_GroupControl
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
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GroupControl));
            this.bPowerMeter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPowerMeter
            // 
            this.bPowerMeter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPowerMeter.BackgroundImage")));
            this.bPowerMeter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bPowerMeter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPowerMeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPowerMeter.ForeColor = System.Drawing.Color.White;
            this.bPowerMeter.Location = new System.Drawing.Point(44, 37);
            this.bPowerMeter.Name = "bPowerMeter";
            this.bPowerMeter.Size = new System.Drawing.Size(279, 97);
            this.bPowerMeter.TabIndex = 0;
            this.bPowerMeter.Text = "KWh";
            this.bPowerMeter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bPowerMeter.UseVisualStyleBackColor = true;
            this.bPowerMeter.Click += new System.EventHandler(this.bPowerMeter_Click);
            // 
            // Form_GroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 568);
            this.Controls.Add(this.bPowerMeter);
            this.Name = "Form_GroupControl";
            this.Text = "Form_GroupControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPowerMeter;
    }
}