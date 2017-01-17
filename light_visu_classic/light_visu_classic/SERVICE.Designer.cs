namespace light_visu_classic
{
    partial class SERVICE
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
            this.richTextBoxReceivedMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxReceivedMessages
            // 
            this.richTextBoxReceivedMessages.Location = new System.Drawing.Point(1, -2);
            this.richTextBoxReceivedMessages.Name = "richTextBoxReceivedMessages";
            this.richTextBoxReceivedMessages.ReadOnly = true;
            this.richTextBoxReceivedMessages.Size = new System.Drawing.Size(639, 217);
            this.richTextBoxReceivedMessages.TabIndex = 0;
            this.richTextBoxReceivedMessages.Text = "";
            // 
            // SERVICE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 216);
            this.Controls.Add(this.richTextBoxReceivedMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SERVICE";
            this.Text = "SERVICE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxReceivedMessages;
    }
}