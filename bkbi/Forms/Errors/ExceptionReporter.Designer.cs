namespace bkbi.Forms.Errors
{
    partial class ExceptionReporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionReporter));
            this.errIcon = new System.Windows.Forms.PictureBox();
            this.errMSG = new System.Windows.Forms.Label();
            this.exViewer = new System.Windows.Forms.DataGridView();
            this.typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeBar = new System.Windows.Forms.ProgressBar();
            this.timeMsgLabel1 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeMsgLabel2 = new System.Windows.Forms.Label();
            this.cntdwnStop = new System.Windows.Forms.Button();
            this.saveInf = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.killButton = new System.Windows.Forms.Button();
            this.saveCrashReportDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // errIcon
            // 
            this.errIcon.Location = new System.Drawing.Point(12, 12);
            this.errIcon.Name = "errIcon";
            this.errIcon.Size = new System.Drawing.Size(64, 64);
            this.errIcon.TabIndex = 0;
            this.errIcon.TabStop = false;
            // 
            // errMSG
            // 
            this.errMSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errMSG.Location = new System.Drawing.Point(82, 12);
            this.errMSG.Name = "errMSG";
            this.errMSG.Size = new System.Drawing.Size(540, 64);
            this.errMSG.TabIndex = 1;
            this.errMSG.Text = resources.GetString("errMSG.Text");
            this.errMSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exViewer
            // 
            this.exViewer.AllowUserToAddRows = false;
            this.exViewer.AllowUserToDeleteRows = false;
            this.exViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.exViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.exViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeColumn,
            this.valueColumn});
            this.exViewer.Location = new System.Drawing.Point(13, 83);
            this.exViewer.Name = "exViewer";
            this.exViewer.ReadOnly = true;
            this.exViewer.Size = new System.Drawing.Size(528, 172);
            this.exViewer.TabIndex = 2;
            // 
            // typeColumn
            // 
            this.typeColumn.HeaderText = "Veri";
            this.typeColumn.Name = "typeColumn";
            this.typeColumn.ReadOnly = true;
            this.typeColumn.Width = 50;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderText = "Değer";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            this.valueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.valueColumn.Width = 61;
            // 
            // timeBar
            // 
            this.timeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeBar.Location = new System.Drawing.Point(352, 269);
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(154, 10);
            this.timeBar.TabIndex = 3;
            // 
            // timeMsgLabel1
            // 
            this.timeMsgLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeMsgLabel1.AutoSize = true;
            this.timeMsgLabel1.Location = new System.Drawing.Point(12, 266);
            this.timeMsgLabel1.Name = "timeMsgLabel1";
            this.timeMsgLabel1.Size = new System.Drawing.Size(88, 13);
            this.timeMsgLabel1.TabIndex = 4;
            this.timeMsgLabel1.Text = "Bu iletişim kutusu";
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(106, 266);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(17, 13);
            this.timeLabel.TabIndex = 5;
            this.timeLabel.Text = "xx";
            // 
            // timeMsgLabel2
            // 
            this.timeMsgLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeMsgLabel2.AutoSize = true;
            this.timeMsgLabel2.Location = new System.Drawing.Point(129, 266);
            this.timeMsgLabel2.Name = "timeMsgLabel2";
            this.timeMsgLabel2.Size = new System.Drawing.Size(217, 13);
            this.timeMsgLabel2.TabIndex = 6;
            this.timeMsgLabel2.Text = "saniye içinde bir şey yapmazsanız kapanıcak";
            // 
            // cntdwnStop
            // 
            this.cntdwnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cntdwnStop.Location = new System.Drawing.Point(512, 261);
            this.cntdwnStop.Name = "cntdwnStop";
            this.cntdwnStop.Size = new System.Drawing.Size(110, 23);
            this.cntdwnStop.TabIndex = 7;
            this.cntdwnStop.Text = "Geri Sayımı Durdur";
            this.cntdwnStop.UseVisualStyleBackColor = true;
            this.cntdwnStop.Click += new System.EventHandler(this.cntdwnStop_Click);
            // 
            // saveInf
            // 
            this.saveInf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveInf.Location = new System.Drawing.Point(547, 209);
            this.saveInf.Name = "saveInf";
            this.saveInf.Size = new System.Drawing.Size(75, 46);
            this.saveInf.TabIndex = 8;
            this.saveInf.Text = "Veriyi Kaydet";
            this.saveInf.UseVisualStyleBackColor = true;
            this.saveInf.Click += new System.EventHandler(this.saveInf_Click);
            // 
            // restartButton
            // 
            this.restartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.restartButton.Location = new System.Drawing.Point(547, 145);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 58);
            this.restartButton.TabIndex = 8;
            this.restartButton.Text = "Programı Yeniden Başlat";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // killButton
            // 
            this.killButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.killButton.Location = new System.Drawing.Point(547, 93);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(75, 46);
            this.killButton.TabIndex = 9;
            this.killButton.Text = "Programı Kapat";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // saveCrashReportDialog
            // 
            this.saveCrashReportDialog.DefaultExt = "xml";
            this.saveCrashReportDialog.Filter = "XML Dosyası|*.xml|Tüm Dosyalar|*.*";
            this.saveCrashReportDialog.SupportMultiDottedExtensions = true;
            this.saveCrashReportDialog.Title = "Save Crash Reporter";
            // 
            // ExceptionReporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 291);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.saveInf);
            this.Controls.Add(this.cntdwnStop);
            this.Controls.Add(this.timeMsgLabel2);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeMsgLabel1);
            this.Controls.Add(this.timeBar);
            this.Controls.Add(this.exViewer);
            this.Controls.Add(this.errMSG);
            this.Controls.Add(this.errIcon);
            this.MinimumSize = new System.Drawing.Size(650, 330);
            this.Name = "ExceptionReporter";
            this.Text = "Kritik Hata: İstisnai Durum";
            ((System.ComponentModel.ISupportInitialize)(this.errIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox errIcon;
        private System.Windows.Forms.Label errMSG;
        private System.Windows.Forms.DataGridView exViewer;
        private System.Windows.Forms.ProgressBar timeBar;
        private System.Windows.Forms.Label timeMsgLabel1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label timeMsgLabel2;
        private System.Windows.Forms.Button cntdwnStop;
        private System.Windows.Forms.Button saveInf;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.SaveFileDialog saveCrashReportDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
    }
}