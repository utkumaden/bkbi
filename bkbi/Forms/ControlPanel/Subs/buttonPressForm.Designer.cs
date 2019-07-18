namespace bkbi.Forms.ControlPanel.Subs
{
    partial class buttonPressForm
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
            this.playersListViewBox = new System.Windows.Forms.ListView();
            this.playersNumColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inGameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playersNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playersPointsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersListViewBox
            // 
            this.playersListViewBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.playersListViewBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playersNumColumn,
            this.inGameColumn,
            this.playersNameColumn,
            this.playersPointsColumn});
            this.playersListViewBox.FullRowSelect = true;
            this.playersListViewBox.GridLines = true;
            this.playersListViewBox.Location = new System.Drawing.Point(12, 12);
            this.playersListViewBox.MultiSelect = false;
            this.playersListViewBox.Name = "playersListViewBox";
            this.playersListViewBox.Size = new System.Drawing.Size(395, 160);
            this.playersListViewBox.TabIndex = 1;
            this.playersListViewBox.UseCompatibleStateImageBehavior = false;
            this.playersListViewBox.View = System.Windows.Forms.View.Details;
            // 
            // playersNumColumn
            // 
            this.playersNumColumn.Text = "#";
            this.playersNumColumn.Width = 23;
            // 
            // inGameColumn
            // 
            this.inGameColumn.Text = "O?";
            this.inGameColumn.Width = 26;
            // 
            // playersNameColumn
            // 
            this.playersNameColumn.Text = "Ad";
            this.playersNameColumn.Width = 271;
            // 
            // playersPointsColumn
            // 
            this.playersPointsColumn.Text = "Puan";
            this.playersPointsColumn.Width = 103;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(319, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Doğru Cevap";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(225, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Yanlış Cevap";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Basan kişiyi seçin.";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(131, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Puan Dağıt";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonPressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playersListViewBox);
            this.Name = "buttonPressForm";
            this.Text = "Düğme Basıldı!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView playersListViewBox;
        private System.Windows.Forms.ColumnHeader playersNumColumn;
        private System.Windows.Forms.ColumnHeader inGameColumn;
        private System.Windows.Forms.ColumnHeader playersNameColumn;
        private System.Windows.Forms.ColumnHeader playersPointsColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}