namespace Bir_Kelime_Bir_Islem.Forms
{
    partial class iExceptionReporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iExceptionReporter));
            this.eyecon = new System.Windows.Forms.PictureBox();
            this.exceptionMessage = new System.Windows.Forms.Label();
            this.exceptionDetails = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eyecon)).BeginInit();
            this.SuspendLayout();
            // 
            // eyecon
            // 
            this.eyecon.Image = ((System.Drawing.Image)(resources.GetObject("eyecon.Image")));
            this.eyecon.Location = new System.Drawing.Point(12, 12);
            this.eyecon.Name = "eyecon";
            this.eyecon.Size = new System.Drawing.Size(64, 64);
            this.eyecon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eyecon.TabIndex = 0;
            this.eyecon.TabStop = false;
            // 
            // exceptionMessage
            // 
            this.exceptionMessage.Location = new System.Drawing.Point(82, 12);
            this.exceptionMessage.Name = "exceptionMessage";
            this.exceptionMessage.Size = new System.Drawing.Size(487, 64);
            this.exceptionMessage.TabIndex = 1;
            this.exceptionMessage.Text = "Hata Mesajı";
            // 
            // exceptionDetails
            // 
            this.exceptionDetails.Location = new System.Drawing.Point(85, 79);
            this.exceptionDetails.Name = "exceptionDetails";
            this.exceptionDetails.ReadOnly = true;
            this.exceptionDetails.Size = new System.Drawing.Size(484, 106);
            this.exceptionDetails.TabIndex = 2;
            this.exceptionDetails.Text = "Hata Detayı";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(494, 191);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Tamam";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // iExceptionReporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 226);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.exceptionDetails);
            this.Controls.Add(this.exceptionMessage);
            this.Controls.Add(this.eyecon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "iExceptionReporter";
            this.Text = "Hata";
            ((System.ComponentModel.ISupportInitialize)(this.eyecon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox eyecon;
        private System.Windows.Forms.Label exceptionMessage;
        private System.Windows.Forms.RichTextBox exceptionDetails;
        private System.Windows.Forms.Button okButton;
    }
}