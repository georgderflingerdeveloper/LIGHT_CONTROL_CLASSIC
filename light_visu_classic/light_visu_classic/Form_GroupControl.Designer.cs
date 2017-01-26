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
            this.buttonLightGroupKitchenOn = new System.Windows.Forms.Button();
            this.buttonLightGroupKitchenOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPowerMeter
            // 
            this.bPowerMeter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPowerMeter.BackgroundImage")));
            this.bPowerMeter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bPowerMeter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPowerMeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPowerMeter.ForeColor = System.Drawing.Color.White;
            this.bPowerMeter.Location = new System.Drawing.Point(33, 30);
            this.bPowerMeter.Margin = new System.Windows.Forms.Padding(2);
            this.bPowerMeter.Name = "bPowerMeter";
            this.bPowerMeter.Size = new System.Drawing.Size(209, 79);
            this.bPowerMeter.TabIndex = 0;
            this.bPowerMeter.Text = "KWh";
            this.bPowerMeter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bPowerMeter.UseVisualStyleBackColor = true;
            this.bPowerMeter.Click += new System.EventHandler(this.bPowerMeter_Click);
            // 
            // buttonLightGroupKitchenOn
            // 
            this.buttonLightGroupKitchenOn.Location = new System.Drawing.Point(33, 131);
            this.buttonLightGroupKitchenOn.Name = "buttonLightGroupKitchenOn";
            this.buttonLightGroupKitchenOn.Size = new System.Drawing.Size(90, 97);
            this.buttonLightGroupKitchenOn.TabIndex = 1;
            this.buttonLightGroupKitchenOn.Text = "LICHT Küche EIN";
            this.buttonLightGroupKitchenOn.UseVisualStyleBackColor = true;
            this.buttonLightGroupKitchenOn.Click += new System.EventHandler(this.buttonLightGroupKitchenOn_Click);
            // 
            // buttonLightGroupKitchenOff
            // 
            this.buttonLightGroupKitchenOff.Location = new System.Drawing.Point(152, 131);
            this.buttonLightGroupKitchenOff.Name = "buttonLightGroupKitchenOff";
            this.buttonLightGroupKitchenOff.Size = new System.Drawing.Size(90, 97);
            this.buttonLightGroupKitchenOff.TabIndex = 2;
            this.buttonLightGroupKitchenOff.Text = "LICHT Küche AUS";
            this.buttonLightGroupKitchenOff.UseVisualStyleBackColor = true;
            this.buttonLightGroupKitchenOff.Click += new System.EventHandler(this.buttonLightGroupKitchenOff_Click);
            // 
            // Form_GroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 462);
            this.Controls.Add(this.buttonLightGroupKitchenOff);
            this.Controls.Add(this.buttonLightGroupKitchenOn);
            this.Controls.Add(this.bPowerMeter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_GroupControl";
            this.Text = "Form_GroupControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPowerMeter;
        private System.Windows.Forms.Button buttonLightGroupKitchenOn;
        private System.Windows.Forms.Button buttonLightGroupKitchenOff;
    }
}