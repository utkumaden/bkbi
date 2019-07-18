namespace Bir_Kelime_Bir_Islem.Forms
{
    partial class viewerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewerForm));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationaryPanel = new System.Windows.Forms.Panel();
            this.PlayerPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.P3plus = new System.Windows.Forms.Label();
            this.P3pm = new System.Windows.Forms.Label();
            this.P3Points = new System.Windows.Forms.Label();
            this.P3name = new System.Windows.Forms.Label();
            this.P3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.P2plus = new System.Windows.Forms.Label();
            this.P2pm = new System.Windows.Forms.Label();
            this.P2Points = new System.Windows.Forms.Label();
            this.P2name = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.P1plus = new System.Windows.Forms.Label();
            this.P1pm = new System.Windows.Forms.Label();
            this.P1Points = new System.Windows.Forms.Label();
            this.P1name = new System.Windows.Forms.Label();
            this.P1Label = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.P3ButtonPress = new System.Windows.Forms.CheckBox();
            this.P2ButtonPress = new System.Windows.Forms.CheckBox();
            this.P1ButtonPress = new System.Windows.Forms.CheckBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.işlemPanel = new System.Windows.Forms.Panel();
            this.jokerPanel = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.işlemKüçükPanel = new System.Windows.Forms.Panel();
            this.PanelH = new System.Windows.Forms.Panel();
            this.H = new System.Windows.Forms.Label();
            this.PanelG = new System.Windows.Forms.Panel();
            this.G = new System.Windows.Forms.Label();
            this.PanelF = new System.Windows.Forms.Panel();
            this.F = new System.Windows.Forms.Label();
            this.PanelE = new System.Windows.Forms.Panel();
            this.E = new System.Windows.Forms.Label();
            this.PanelD = new System.Windows.Forms.Panel();
            this.D = new System.Windows.Forms.Label();
            this.PanelC = new System.Windows.Forms.Panel();
            this.C = new System.Windows.Forms.Label();
            this.PanelB = new System.Windows.Forms.Panel();
            this.B = new System.Windows.Forms.Label();
            this.PanelA = new System.Windows.Forms.Panel();
            this.A = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.stationaryPanel.SuspendLayout();
            this.PlayerPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.işlemPanel.SuspendLayout();
            this.jokerPanel.SuspendLayout();
            this.işlemKüçükPanel.SuspendLayout();
            this.PanelH.SuspendLayout();
            this.PanelG.SuspendLayout();
            this.PanelF.SuspendLayout();
            this.PanelE.SuspendLayout();
            this.PanelD.SuspendLayout();
            this.PanelC.SuspendLayout();
            this.PanelB.SuspendLayout();
            this.PanelA.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(107, 48);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.moveToolStripMenuItem.Text = "Kapat";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.closeToolStripMenuItem.Text = "Oynat";
            // 
            // stationaryPanel
            // 
            this.stationaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationaryPanel.BackColor = System.Drawing.Color.Transparent;
            this.stationaryPanel.Controls.Add(this.PlayerPanel);
            this.stationaryPanel.Controls.Add(this.timePanel);
            this.stationaryPanel.Location = new System.Drawing.Point(13, 427);
            this.stationaryPanel.Name = "stationaryPanel";
            this.stationaryPanel.Size = new System.Drawing.Size(915, 113);
            this.stationaryPanel.TabIndex = 1;
            // 
            // PlayerPanel
            // 
            this.PlayerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerPanel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerPanel.Controls.Add(this.panel3);
            this.PlayerPanel.Controls.Add(this.panel2);
            this.PlayerPanel.Controls.Add(this.panel1);
            this.PlayerPanel.Location = new System.Drawing.Point(579, 4);
            this.PlayerPanel.Name = "PlayerPanel";
            this.PlayerPanel.Size = new System.Drawing.Size(333, 106);
            this.PlayerPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.P3plus);
            this.panel3.Controls.Add(this.P3pm);
            this.panel3.Controls.Add(this.P3Points);
            this.panel3.Controls.Add(this.P3name);
            this.panel3.Controls.Add(this.P3);
            this.panel3.Location = new System.Drawing.Point(230, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 100);
            this.panel3.TabIndex = 2;
            // 
            // P3plus
            // 
            this.P3plus.AutoSize = true;
            this.P3plus.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3plus.ForeColor = System.Drawing.Color.Lime;
            this.P3plus.Location = new System.Drawing.Point(61, 76);
            this.P3plus.Name = "P3plus";
            this.P3plus.Size = new System.Drawing.Size(16, 16);
            this.P3plus.TabIndex = 8;
            this.P3plus.Text = "+";
            this.P3plus.Visible = false;
            // 
            // P3pm
            // 
            this.P3pm.AutoSize = true;
            this.P3pm.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3pm.ForeColor = System.Drawing.Color.Lime;
            this.P3pm.Location = new System.Drawing.Point(71, 76);
            this.P3pm.Name = "P3pm";
            this.P3pm.Size = new System.Drawing.Size(15, 16);
            this.P3pm.TabIndex = 7;
            this.P3pm.Text = "0";
            this.P3pm.Visible = false;
            this.P3pm.VisibleChanged += new System.EventHandler(this.P3pm_VisibleChanged);
            // 
            // P3Points
            // 
            this.P3Points.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3Points.ForeColor = System.Drawing.Color.White;
            this.P3Points.Location = new System.Drawing.Point(-18, 69);
            this.P3Points.Name = "P3Points";
            this.P3Points.Size = new System.Drawing.Size(86, 26);
            this.P3Points.TabIndex = 4;
            this.P3Points.Text = "0";
            this.P3Points.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // P3name
            // 
            this.P3name.AutoSize = true;
            this.P3name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.P3name.ForeColor = System.Drawing.Color.White;
            this.P3name.Location = new System.Drawing.Point(3, 32);
            this.P3name.Name = "P3name";
            this.P3name.Size = new System.Drawing.Size(98, 18);
            this.P3name.TabIndex = 3;
            this.P3name.Text = "Abdulrezak";
            // 
            // P3
            // 
            this.P3.AutoSize = true;
            this.P3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3.ForeColor = System.Drawing.Color.White;
            this.P3.Location = new System.Drawing.Point(3, 3);
            this.P3.Name = "P3";
            this.P3.Size = new System.Drawing.Size(38, 25);
            this.P3.TabIndex = 2;
            this.P3.Text = "P3";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.P2plus);
            this.panel2.Controls.Add(this.P2pm);
            this.panel2.Controls.Add(this.P2Points);
            this.panel2.Controls.Add(this.P2name);
            this.panel2.Controls.Add(this.P2);
            this.panel2.Location = new System.Drawing.Point(124, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 1;
            // 
            // P2plus
            // 
            this.P2plus.AutoSize = true;
            this.P2plus.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2plus.ForeColor = System.Drawing.Color.Lime;
            this.P2plus.Location = new System.Drawing.Point(61, 76);
            this.P2plus.Name = "P2plus";
            this.P2plus.Size = new System.Drawing.Size(16, 16);
            this.P2plus.TabIndex = 7;
            this.P2plus.Text = "+";
            this.P2plus.Visible = false;
            // 
            // P2pm
            // 
            this.P2pm.AutoSize = true;
            this.P2pm.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2pm.ForeColor = System.Drawing.Color.Lime;
            this.P2pm.Location = new System.Drawing.Point(74, 76);
            this.P2pm.Name = "P2pm";
            this.P2pm.Size = new System.Drawing.Size(15, 16);
            this.P2pm.TabIndex = 6;
            this.P2pm.Text = "0";
            this.P2pm.Visible = false;
            this.P2pm.VisibleChanged += new System.EventHandler(this.P2pm_VisibleChanged);
            // 
            // P2Points
            // 
            this.P2Points.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Points.ForeColor = System.Drawing.Color.White;
            this.P2Points.Location = new System.Drawing.Point(-26, 69);
            this.P2Points.Name = "P2Points";
            this.P2Points.Size = new System.Drawing.Size(91, 26);
            this.P2Points.TabIndex = 3;
            this.P2Points.Text = "0";
            this.P2Points.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // P2name
            // 
            this.P2name.AutoSize = true;
            this.P2name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.P2name.ForeColor = System.Drawing.Color.White;
            this.P2name.Location = new System.Drawing.Point(3, 32);
            this.P2name.Name = "P2name";
            this.P2name.Size = new System.Drawing.Size(98, 18);
            this.P2name.TabIndex = 2;
            this.P2name.Text = "Abdulrezak";
            // 
            // P2
            // 
            this.P2.AutoSize = true;
            this.P2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2.ForeColor = System.Drawing.Color.White;
            this.P2.Location = new System.Drawing.Point(3, 3);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(38, 25);
            this.P2.TabIndex = 1;
            this.P2.Text = "P2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.P1plus);
            this.panel1.Controls.Add(this.P1pm);
            this.panel1.Controls.Add(this.P1Points);
            this.panel1.Controls.Add(this.P1name);
            this.panel1.Controls.Add(this.P1Label);
            this.panel1.Location = new System.Drawing.Point(18, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            // 
            // P1plus
            // 
            this.P1plus.AutoSize = true;
            this.P1plus.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1plus.ForeColor = System.Drawing.Color.Lime;
            this.P1plus.Location = new System.Drawing.Point(61, 76);
            this.P1plus.Name = "P1plus";
            this.P1plus.Size = new System.Drawing.Size(16, 16);
            this.P1plus.TabIndex = 6;
            this.P1plus.Text = "+";
            this.P1plus.Visible = false;
            // 
            // P1pm
            // 
            this.P1pm.AutoSize = true;
            this.P1pm.Font = new System.Drawing.Font("LCD Solid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1pm.ForeColor = System.Drawing.Color.Lime;
            this.P1pm.Location = new System.Drawing.Point(72, 76);
            this.P1pm.Name = "P1pm";
            this.P1pm.Size = new System.Drawing.Size(15, 16);
            this.P1pm.TabIndex = 5;
            this.P1pm.Text = "0";
            this.P1pm.Visible = false;
            this.P1pm.VisibleChanged += new System.EventHandler(this.P1pm_VisibleChanged);
            // 
            // P1Points
            // 
            this.P1Points.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Points.ForeColor = System.Drawing.Color.White;
            this.P1Points.Location = new System.Drawing.Point(-15, 69);
            this.P1Points.Name = "P1Points";
            this.P1Points.Size = new System.Drawing.Size(82, 26);
            this.P1Points.TabIndex = 4;
            this.P1Points.Text = "0";
            this.P1Points.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // P1name
            // 
            this.P1name.AutoSize = true;
            this.P1name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.P1name.ForeColor = System.Drawing.Color.White;
            this.P1name.Location = new System.Drawing.Point(4, 32);
            this.P1name.Name = "P1name";
            this.P1name.Size = new System.Drawing.Size(98, 18);
            this.P1name.TabIndex = 1;
            this.P1name.Text = "Abdulrezak";
            // 
            // P1Label
            // 
            this.P1Label.AutoSize = true;
            this.P1Label.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Label.ForeColor = System.Drawing.Color.White;
            this.P1Label.Location = new System.Drawing.Point(3, 3);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(38, 25);
            this.P1Label.TabIndex = 0;
            this.P1Label.Text = "P1";
            // 
            // timePanel
            // 
            this.timePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.timePanel.BackColor = System.Drawing.Color.Maroon;
            this.timePanel.Controls.Add(this.P3ButtonPress);
            this.timePanel.Controls.Add(this.P2ButtonPress);
            this.timePanel.Controls.Add(this.P1ButtonPress);
            this.timePanel.Controls.Add(this.timeLabel);
            this.timePanel.Controls.Add(this.label17);
            this.timePanel.Location = new System.Drawing.Point(4, 4);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(357, 106);
            this.timePanel.TabIndex = 0;
            // 
            // P3ButtonPress
            // 
            this.P3ButtonPress.Appearance = System.Windows.Forms.Appearance.Button;
            this.P3ButtonPress.AutoSize = true;
            this.P3ButtonPress.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3ButtonPress.Location = new System.Drawing.Point(213, 67);
            this.P3ButtonPress.Name = "P3ButtonPress";
            this.P3ButtonPress.Size = new System.Drawing.Size(64, 46);
            this.P3ButtonPress.TabIndex = 4;
            this.P3ButtonPress.Text = "P3";
            this.P3ButtonPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.P3ButtonPress.UseVisualStyleBackColor = true;
            // 
            // P2ButtonPress
            // 
            this.P2ButtonPress.Appearance = System.Windows.Forms.Appearance.Button;
            this.P2ButtonPress.AutoSize = true;
            this.P2ButtonPress.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2ButtonPress.Location = new System.Drawing.Point(145, 67);
            this.P2ButtonPress.Name = "P2ButtonPress";
            this.P2ButtonPress.Size = new System.Drawing.Size(64, 46);
            this.P2ButtonPress.TabIndex = 3;
            this.P2ButtonPress.Text = "P2";
            this.P2ButtonPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.P2ButtonPress.UseVisualStyleBackColor = true;
            // 
            // P1ButtonPress
            // 
            this.P1ButtonPress.Appearance = System.Windows.Forms.Appearance.Button;
            this.P1ButtonPress.AutoSize = true;
            this.P1ButtonPress.Font = new System.Drawing.Font("LCD Solid", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1ButtonPress.Location = new System.Drawing.Point(77, 67);
            this.P1ButtonPress.Name = "P1ButtonPress";
            this.P1ButtonPress.Size = new System.Drawing.Size(64, 46);
            this.P1ButtonPress.TabIndex = 2;
            this.P1ButtonPress.Text = "P1";
            this.P1ButtonPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.P1ButtonPress.UseVisualStyleBackColor = true;
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("LCD Solid", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(279, 6);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(75, 38);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("LCD Solid", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(187, 55);
            this.label17.TabIndex = 0;
            this.label17.Text = "Zaman:";
            // 
            // işlemPanel
            // 
            this.işlemPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.işlemPanel.BackColor = System.Drawing.Color.Transparent;
            this.işlemPanel.Controls.Add(this.jokerPanel);
            this.işlemPanel.Controls.Add(this.GameLabel);
            this.işlemPanel.Controls.Add(this.işlemKüçükPanel);
            this.işlemPanel.Location = new System.Drawing.Point(13, 13);
            this.işlemPanel.Name = "işlemPanel";
            this.işlemPanel.Size = new System.Drawing.Size(915, 408);
            this.işlemPanel.TabIndex = 2;
            // 
            // jokerPanel
            // 
            this.jokerPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jokerPanel.BackColor = System.Drawing.Color.Maroon;
            this.jokerPanel.Controls.Add(this.label21);
            this.jokerPanel.Controls.Add(this.label22);
            this.jokerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.jokerPanel.Location = new System.Drawing.Point(420, 277);
            this.jokerPanel.Name = "jokerPanel";
            this.jokerPanel.Size = new System.Drawing.Size(100, 100);
            this.jokerPanel.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(9, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 78);
            this.label21.TabIndex = 2;
            this.label21.Text = "?";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(18, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 55);
            this.label22.TabIndex = 0;
            // 
            // GameLabel
            // 
            this.GameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameLabel.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GameLabel.Location = new System.Drawing.Point(380, 28);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(181, 38);
            this.GameLabel.TabIndex = 9;
            this.GameLabel.Text = "Bir Kelime";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // işlemKüçükPanel
            // 
            this.işlemKüçükPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.işlemKüçükPanel.Controls.Add(this.PanelH);
            this.işlemKüçükPanel.Controls.Add(this.PanelG);
            this.işlemKüçükPanel.Controls.Add(this.PanelF);
            this.işlemKüçükPanel.Controls.Add(this.PanelE);
            this.işlemKüçükPanel.Controls.Add(this.PanelD);
            this.işlemKüçükPanel.Controls.Add(this.PanelC);
            this.işlemKüçükPanel.Controls.Add(this.PanelB);
            this.işlemKüçükPanel.Controls.Add(this.PanelA);
            this.işlemKüçükPanel.Location = new System.Drawing.Point(46, 164);
            this.işlemKüçükPanel.Name = "işlemKüçükPanel";
            this.işlemKüçükPanel.Size = new System.Drawing.Size(849, 107);
            this.işlemKüçükPanel.TabIndex = 8;
            // 
            // PanelH
            // 
            this.PanelH.BackColor = System.Drawing.Color.Maroon;
            this.PanelH.Controls.Add(this.H);
            this.PanelH.Location = new System.Drawing.Point(746, 4);
            this.PanelH.Name = "PanelH";
            this.PanelH.Size = new System.Drawing.Size(100, 100);
            this.PanelH.TabIndex = 1;
            // 
            // H
            // 
            this.H.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H.ForeColor = System.Drawing.Color.White;
            this.H.Location = new System.Drawing.Point(8, 10);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(83, 78);
            this.H.TabIndex = 3;
            this.H.Text = "O";
            this.H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelG
            // 
            this.PanelG.BackColor = System.Drawing.Color.Maroon;
            this.PanelG.Controls.Add(this.G);
            this.PanelG.Location = new System.Drawing.Point(640, 4);
            this.PanelG.Name = "PanelG";
            this.PanelG.Size = new System.Drawing.Size(100, 100);
            this.PanelG.TabIndex = 1;
            // 
            // G
            // 
            this.G.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G.ForeColor = System.Drawing.Color.White;
            this.G.Location = new System.Drawing.Point(10, 10);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(83, 78);
            this.G.TabIndex = 4;
            this.G.Text = "O";
            this.G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelF
            // 
            this.PanelF.BackColor = System.Drawing.Color.Maroon;
            this.PanelF.Controls.Add(this.F);
            this.PanelF.Location = new System.Drawing.Point(534, 4);
            this.PanelF.Name = "PanelF";
            this.PanelF.Size = new System.Drawing.Size(100, 100);
            this.PanelF.TabIndex = 1;
            // 
            // F
            // 
            this.F.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.F.ForeColor = System.Drawing.Color.White;
            this.F.Location = new System.Drawing.Point(11, 10);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(83, 78);
            this.F.TabIndex = 5;
            this.F.Text = "O";
            this.F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelE
            // 
            this.PanelE.BackColor = System.Drawing.Color.Maroon;
            this.PanelE.Controls.Add(this.E);
            this.PanelE.Location = new System.Drawing.Point(428, 4);
            this.PanelE.Name = "PanelE";
            this.PanelE.Size = new System.Drawing.Size(100, 100);
            this.PanelE.TabIndex = 1;
            // 
            // E
            // 
            this.E.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E.ForeColor = System.Drawing.Color.White;
            this.E.Location = new System.Drawing.Point(14, 10);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(83, 78);
            this.E.TabIndex = 6;
            this.E.Text = "O";
            this.E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelD
            // 
            this.PanelD.BackColor = System.Drawing.Color.Maroon;
            this.PanelD.Controls.Add(this.D);
            this.PanelD.Location = new System.Drawing.Point(322, 4);
            this.PanelD.Name = "PanelD";
            this.PanelD.Size = new System.Drawing.Size(100, 100);
            this.PanelD.TabIndex = 1;
            // 
            // D
            // 
            this.D.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.ForeColor = System.Drawing.Color.White;
            this.D.Location = new System.Drawing.Point(6, 10);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(83, 78);
            this.D.TabIndex = 6;
            this.D.Text = "O";
            this.D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelC
            // 
            this.PanelC.BackColor = System.Drawing.Color.Maroon;
            this.PanelC.Controls.Add(this.C);
            this.PanelC.Location = new System.Drawing.Point(216, 4);
            this.PanelC.Name = "PanelC";
            this.PanelC.Size = new System.Drawing.Size(100, 100);
            this.PanelC.TabIndex = 1;
            // 
            // C
            // 
            this.C.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C.ForeColor = System.Drawing.Color.White;
            this.C.Location = new System.Drawing.Point(9, 9);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(83, 78);
            this.C.TabIndex = 7;
            this.C.Text = "O";
            this.C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelB
            // 
            this.PanelB.BackColor = System.Drawing.Color.Maroon;
            this.PanelB.Controls.Add(this.B);
            this.PanelB.Location = new System.Drawing.Point(110, 4);
            this.PanelB.Name = "PanelB";
            this.PanelB.Size = new System.Drawing.Size(100, 100);
            this.PanelB.TabIndex = 1;
            // 
            // B
            // 
            this.B.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B.ForeColor = System.Drawing.Color.White;
            this.B.Location = new System.Drawing.Point(11, 10);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(83, 78);
            this.B.TabIndex = 8;
            this.B.Text = "O";
            this.B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelA
            // 
            this.PanelA.BackColor = System.Drawing.Color.Maroon;
            this.PanelA.Controls.Add(this.A);
            this.PanelA.Location = new System.Drawing.Point(4, 4);
            this.PanelA.Name = "PanelA";
            this.PanelA.Size = new System.Drawing.Size(100, 100);
            this.PanelA.TabIndex = 0;
            // 
            // A
            // 
            this.A.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A.ForeColor = System.Drawing.Color.White;
            this.A.Location = new System.Drawing.Point(10, 10);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(83, 78);
            this.A.TabIndex = 8;
            this.A.Text = "O";
            this.A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 552);
            this.ControlBox = false;
            this.Controls.Add(this.stationaryPanel);
            this.Controls.Add(this.işlemPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "viewerForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "İzleyici Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.viewerForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.doubleClick);
            this.menu.ResumeLayout(false);
            this.stationaryPanel.ResumeLayout(false);
            this.PlayerPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.işlemPanel.ResumeLayout(false);
            this.jokerPanel.ResumeLayout(false);
            this.jokerPanel.PerformLayout();
            this.işlemKüçükPanel.ResumeLayout(false);
            this.PanelH.ResumeLayout(false);
            this.PanelG.ResumeLayout(false);
            this.PanelF.ResumeLayout(false);
            this.PanelE.ResumeLayout(false);
            this.PanelD.ResumeLayout(false);
            this.PanelC.ResumeLayout(false);
            this.PanelB.ResumeLayout(false);
            this.PanelA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel stationaryPanel;
        private System.Windows.Forms.Panel PlayerPanel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel işlemKüçükPanel;
        private System.Windows.Forms.Label P3;
        private System.Windows.Forms.Label P2;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label timeLabel;
        public System.Windows.Forms.CheckBox P3ButtonPress;
        public System.Windows.Forms.CheckBox P2ButtonPress;
        public System.Windows.Forms.CheckBox P1ButtonPress;
        public System.Windows.Forms.Label P3pm;
        public System.Windows.Forms.Label P3Points;
        public System.Windows.Forms.Label P3name;
        public System.Windows.Forms.Label P2pm;
        public System.Windows.Forms.Label P2Points;
        public System.Windows.Forms.Label P2name;
        public System.Windows.Forms.Label P1pm;
        public System.Windows.Forms.Label P1Points;
        public System.Windows.Forms.Label P1name;
        public System.Windows.Forms.Label GameLabel;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Panel jokerPanel;
        public System.Windows.Forms.Label P3plus;
        public System.Windows.Forms.Label P2plus;
        public System.Windows.Forms.Label P1plus;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel işlemPanel;
        public System.Windows.Forms.Label H;
        public System.Windows.Forms.Label G;
        public System.Windows.Forms.Label F;
        public System.Windows.Forms.Label E;
        public System.Windows.Forms.Label D;
        public System.Windows.Forms.Label C;
        public System.Windows.Forms.Label B;
        public System.Windows.Forms.Label A;
        public System.Windows.Forms.Panel PanelH;
        public System.Windows.Forms.Panel PanelG;
        public System.Windows.Forms.Panel PanelF;
        public System.Windows.Forms.Panel PanelE;
        public System.Windows.Forms.Panel PanelD;
        public System.Windows.Forms.Panel PanelC;
        public System.Windows.Forms.Panel PanelB;
        public System.Windows.Forms.Panel PanelA;
    }
}