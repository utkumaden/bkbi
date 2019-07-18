namespace Bir_Kelime_Bir_Islem.Forms.Main
{
    partial class console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(console));
            this.outbox = new System.Windows.Forms.RichTextBox();
            this.inbox = new System.Windows.Forms.TextBox();
            this.sendCmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outbox
            // 
            this.outbox.Location = new System.Drawing.Point(13, 13);
            this.outbox.Name = "outbox";
            this.outbox.Size = new System.Drawing.Size(532, 244);
            this.outbox.TabIndex = 0;
            this.outbox.Text = "";
            // 
            // inbox
            // 
            this.inbox.Location = new System.Drawing.Point(13, 266);
            this.inbox.Name = "inbox";
            this.inbox.Size = new System.Drawing.Size(451, 20);
            this.inbox.TabIndex = 1;
            // 
            // sendCmd
            // 
            this.sendCmd.Location = new System.Drawing.Point(470, 263);
            this.sendCmd.Name = "sendCmd";
            this.sendCmd.Size = new System.Drawing.Size(75, 23);
            this.sendCmd.TabIndex = 2;
            this.sendCmd.Text = "Gönder";
            this.sendCmd.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.AcceptButton = this.sendCmd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 298);
            this.Controls.Add(this.sendCmd);
            this.Controls.Add(this.inbox);
            this.Controls.Add(this.outbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "console";
            this.Text = "Konsol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox outbox;
        public System.Windows.Forms.TextBox inbox;
        public System.Windows.Forms.Button sendCmd;
    }
}