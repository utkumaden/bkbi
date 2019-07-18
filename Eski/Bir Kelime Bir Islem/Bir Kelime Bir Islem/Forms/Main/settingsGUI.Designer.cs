namespace Bir_Kelime_Bir_Islem.Forms.Main
{
    partial class settingsGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsGUI));
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prePreparedGameGroupBox = new System.Windows.Forms.GroupBox();
            this.autoPrePreparedGameGroupBox = new System.Windows.Forms.GroupBox();
            this.autoPrePreparedGamePathTextBox = new System.Windows.Forms.TextBox();
            this.browseGamesButton = new System.Windows.Forms.Button();
            this.useAutoPrePreparedGame = new System.Windows.Forms.CheckBox();
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox = new System.Windows.Forms.CheckBox();
            this.ArduinoGroupBox = new System.Windows.Forms.GroupBox();
            this.arduinoCodeShowButton = new System.Windows.Forms.Button();
            this.ArduinoPortLabel = new System.Windows.Forms.Label();
            this.arduinoPortBox = new System.Windows.Forms.TextBox();
            this.useArduinoIntegrationCheckBox = new System.Windows.Forms.CheckBox();
            this.settingTabsTabControl = new System.Windows.Forms.TabControl();
            this.soundTabPage = new System.Windows.Forms.TabPage();
            this.SoundGroupBox = new System.Windows.Forms.GroupBox();
            this.specialBox = new System.Windows.Forms.GroupBox();
            this.soundPathTextBlx = new System.Windows.Forms.TextBox();
            this.browseSoundsButton = new System.Windows.Forms.Button();
            this.muteSpecificSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.speciaSoundOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.generalSoundSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.muteRadioButton = new System.Windows.Forms.RadioButton();
            this.useSpecialRadioButton = new System.Windows.Forms.RadioButton();
            this.useBeepsRadioButton = new System.Windows.Forms.RadioButton();
            this.useDefaultSoundsRadioButton = new System.Windows.Forms.RadioButton();
            this.applyButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openSound = new System.Windows.Forms.OpenFileDialog();
            this.openPrePreparedGame = new System.Windows.Forms.OpenFileDialog();
            this.generalTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.prePreparedGameGroupBox.SuspendLayout();
            this.autoPrePreparedGameGroupBox.SuspendLayout();
            this.ArduinoGroupBox.SuspendLayout();
            this.settingTabsTabControl.SuspendLayout();
            this.soundTabPage.SuspendLayout();
            this.SoundGroupBox.SuspendLayout();
            this.specialBox.SuspendLayout();
            this.generalSoundSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.groupBox1);
            this.generalTabPage.Controls.Add(this.prePreparedGameGroupBox);
            this.generalTabPage.Controls.Add(this.ArduinoGroupBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(423, 186);
            this.generalTabPage.TabIndex = 1;
            this.generalTabPage.Text = "Genel";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 37);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zamanlama";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(115, 13);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(289, 20);
            this.timeBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kaç Saniye Verilsin?";
            // 
            // prePreparedGameGroupBox
            // 
            this.prePreparedGameGroupBox.Controls.Add(this.autoPrePreparedGameGroupBox);
            this.prePreparedGameGroupBox.Controls.Add(this.usePrePreparedSettingsFromPrePreparedGamesChechBox);
            this.prePreparedGameGroupBox.Location = new System.Drawing.Point(173, 7);
            this.prePreparedGameGroupBox.Name = "prePreparedGameGroupBox";
            this.prePreparedGameGroupBox.Size = new System.Drawing.Size(244, 132);
            this.prePreparedGameGroupBox.TabIndex = 2;
            this.prePreparedGameGroupBox.TabStop = false;
            this.prePreparedGameGroupBox.Text = "Hazır Oyun";
            // 
            // autoPrePreparedGameGroupBox
            // 
            this.autoPrePreparedGameGroupBox.Controls.Add(this.autoPrePreparedGamePathTextBox);
            this.autoPrePreparedGameGroupBox.Controls.Add(this.browseGamesButton);
            this.autoPrePreparedGameGroupBox.Controls.Add(this.useAutoPrePreparedGame);
            this.autoPrePreparedGameGroupBox.Location = new System.Drawing.Point(7, 43);
            this.autoPrePreparedGameGroupBox.Name = "autoPrePreparedGameGroupBox";
            this.autoPrePreparedGameGroupBox.Size = new System.Drawing.Size(231, 81);
            this.autoPrePreparedGameGroupBox.TabIndex = 2;
            this.autoPrePreparedGameGroupBox.TabStop = false;
            this.autoPrePreparedGameGroupBox.Text = "Otomatik Hazır Oyun";
            // 
            // autoPrePreparedGamePathTextBox
            // 
            this.autoPrePreparedGamePathTextBox.Location = new System.Drawing.Point(6, 53);
            this.autoPrePreparedGamePathTextBox.Name = "autoPrePreparedGamePathTextBox";
            this.autoPrePreparedGamePathTextBox.Size = new System.Drawing.Size(138, 20);
            this.autoPrePreparedGamePathTextBox.TabIndex = 3;
            // 
            // browseGamesButton
            // 
            this.browseGamesButton.Image = ((System.Drawing.Image)(resources.GetObject("browseGamesButton.Image")));
            this.browseGamesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseGamesButton.Location = new System.Drawing.Point(150, 51);
            this.browseGamesButton.Name = "browseGamesButton";
            this.browseGamesButton.Size = new System.Drawing.Size(75, 24);
            this.browseGamesButton.TabIndex = 2;
            this.browseGamesButton.Text = "Gözat";
            this.browseGamesButton.UseVisualStyleBackColor = true;
            this.browseGamesButton.Click += new System.EventHandler(this.browseGamesButton_Click);
            // 
            // useAutoPrePreparedGame
            // 
            this.useAutoPrePreparedGame.AutoSize = true;
            this.useAutoPrePreparedGame.Location = new System.Drawing.Point(6, 19);
            this.useAutoPrePreparedGame.Name = "useAutoPrePreparedGame";
            this.useAutoPrePreparedGame.Size = new System.Drawing.Size(153, 17);
            this.useAutoPrePreparedGame.TabIndex = 1;
            this.useAutoPrePreparedGame.Text = "Otomatik Hazır Oyun Yükle";
            this.useAutoPrePreparedGame.UseVisualStyleBackColor = true;
            // 
            // usePrePreparedSettingsFromPrePreparedGamesChechBox
            // 
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.AutoSize = true;
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.Location = new System.Drawing.Point(7, 20);
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.Name = "usePrePreparedSettingsFromPrePreparedGamesChechBox";
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.Size = new System.Drawing.Size(196, 17);
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.TabIndex = 0;
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.Text = "Hazır Oyundan Gelen Ayarları Kullan";
            this.usePrePreparedSettingsFromPrePreparedGamesChechBox.UseVisualStyleBackColor = true;
            // 
            // ArduinoGroupBox
            // 
            this.ArduinoGroupBox.Controls.Add(this.arduinoCodeShowButton);
            this.ArduinoGroupBox.Controls.Add(this.ArduinoPortLabel);
            this.ArduinoGroupBox.Controls.Add(this.arduinoPortBox);
            this.ArduinoGroupBox.Controls.Add(this.useArduinoIntegrationCheckBox);
            this.ArduinoGroupBox.Enabled = false;
            this.ArduinoGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ArduinoGroupBox.Name = "ArduinoGroupBox";
            this.ArduinoGroupBox.Size = new System.Drawing.Size(161, 133);
            this.ArduinoGroupBox.TabIndex = 1;
            this.ArduinoGroupBox.TabStop = false;
            this.ArduinoGroupBox.Text = "Arduino";
            // 
            // arduinoCodeShowButton
            // 
            this.arduinoCodeShowButton.Image = ((System.Drawing.Image)(resources.GetObject("arduinoCodeShowButton.Image")));
            this.arduinoCodeShowButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.arduinoCodeShowButton.Location = new System.Drawing.Point(7, 63);
            this.arduinoCodeShowButton.Name = "arduinoCodeShowButton";
            this.arduinoCodeShowButton.Size = new System.Drawing.Size(148, 64);
            this.arduinoCodeShowButton.TabIndex = 3;
            this.arduinoCodeShowButton.Text = "Arduino Programı İçin Tıklayın";
            this.arduinoCodeShowButton.UseVisualStyleBackColor = true;
            // 
            // ArduinoPortLabel
            // 
            this.ArduinoPortLabel.AutoSize = true;
            this.ArduinoPortLabel.Location = new System.Drawing.Point(6, 40);
            this.ArduinoPortLabel.Name = "ArduinoPortLabel";
            this.ArduinoPortLabel.Size = new System.Drawing.Size(29, 13);
            this.ArduinoPortLabel.TabIndex = 2;
            this.ArduinoPortLabel.Text = "Port:";
            // 
            // arduinoPortBox
            // 
            this.arduinoPortBox.Location = new System.Drawing.Point(41, 37);
            this.arduinoPortBox.Name = "arduinoPortBox";
            this.arduinoPortBox.Size = new System.Drawing.Size(114, 20);
            this.arduinoPortBox.TabIndex = 1;
            // 
            // useArduinoIntegrationCheckBox
            // 
            this.useArduinoIntegrationCheckBox.AutoSize = true;
            this.useArduinoIntegrationCheckBox.Location = new System.Drawing.Point(7, 20);
            this.useArduinoIntegrationCheckBox.Name = "useArduinoIntegrationCheckBox";
            this.useArduinoIntegrationCheckBox.Size = new System.Drawing.Size(123, 17);
            this.useArduinoIntegrationCheckBox.TabIndex = 0;
            this.useArduinoIntegrationCheckBox.Text = "Entegrasyonu Kullan";
            this.useArduinoIntegrationCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingTabsTabControl
            // 
            this.settingTabsTabControl.Controls.Add(this.generalTabPage);
            this.settingTabsTabControl.Controls.Add(this.soundTabPage);
            this.settingTabsTabControl.Location = new System.Drawing.Point(12, 3);
            this.settingTabsTabControl.Name = "settingTabsTabControl";
            this.settingTabsTabControl.SelectedIndex = 0;
            this.settingTabsTabControl.Size = new System.Drawing.Size(431, 212);
            this.settingTabsTabControl.TabIndex = 0;
            // 
            // soundTabPage
            // 
            this.soundTabPage.Controls.Add(this.SoundGroupBox);
            this.soundTabPage.Controls.Add(this.generalSoundSettingsGroupBox);
            this.soundTabPage.Location = new System.Drawing.Point(4, 22);
            this.soundTabPage.Name = "soundTabPage";
            this.soundTabPage.Size = new System.Drawing.Size(423, 186);
            this.soundTabPage.TabIndex = 2;
            this.soundTabPage.Text = "Ses";
            this.soundTabPage.UseVisualStyleBackColor = true;
            // 
            // SoundGroupBox
            // 
            this.SoundGroupBox.Controls.Add(this.specialBox);
            this.SoundGroupBox.Controls.Add(this.muteSpecificSoundCheckBox);
            this.SoundGroupBox.Controls.Add(this.speciaSoundOptionsComboBox);
            this.SoundGroupBox.Location = new System.Drawing.Point(222, 8);
            this.SoundGroupBox.Name = "SoundGroupBox";
            this.SoundGroupBox.Size = new System.Drawing.Size(198, 175);
            this.SoundGroupBox.TabIndex = 1;
            this.SoundGroupBox.TabStop = false;
            this.SoundGroupBox.Text = "Özel";
            // 
            // specialBox
            // 
            this.specialBox.Controls.Add(this.soundPathTextBlx);
            this.specialBox.Controls.Add(this.browseSoundsButton);
            this.specialBox.Location = new System.Drawing.Point(7, 67);
            this.specialBox.Name = "specialBox";
            this.specialBox.Size = new System.Drawing.Size(185, 53);
            this.specialBox.TabIndex = 4;
            this.specialBox.TabStop = false;
            this.specialBox.Text = "Kişisel";
            // 
            // soundPathTextBlx
            // 
            this.soundPathTextBlx.Location = new System.Drawing.Point(6, 19);
            this.soundPathTextBlx.Name = "soundPathTextBlx";
            this.soundPathTextBlx.Size = new System.Drawing.Size(92, 20);
            this.soundPathTextBlx.TabIndex = 2;
            this.soundPathTextBlx.TextChanged += new System.EventHandler(this.soundPathTextBlx_TextChanged);
            // 
            // browseSoundsButton
            // 
            this.browseSoundsButton.Image = ((System.Drawing.Image)(resources.GetObject("browseSoundsButton.Image")));
            this.browseSoundsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseSoundsButton.Location = new System.Drawing.Point(104, 17);
            this.browseSoundsButton.Name = "browseSoundsButton";
            this.browseSoundsButton.Size = new System.Drawing.Size(75, 24);
            this.browseSoundsButton.TabIndex = 3;
            this.browseSoundsButton.Text = "Gözat";
            this.browseSoundsButton.UseVisualStyleBackColor = true;
            this.browseSoundsButton.Click += new System.EventHandler(this.browseSoundsButton_Click);
            // 
            // muteSpecificSoundCheckBox
            // 
            this.muteSpecificSoundCheckBox.AutoSize = true;
            this.muteSpecificSoundCheckBox.Location = new System.Drawing.Point(7, 48);
            this.muteSpecificSoundCheckBox.Name = "muteSpecificSoundCheckBox";
            this.muteSpecificSoundCheckBox.Size = new System.Drawing.Size(93, 17);
            this.muteSpecificSoundCheckBox.TabIndex = 1;
            this.muteSpecificSoundCheckBox.Text = "Bu Sesi Kapat";
            this.muteSpecificSoundCheckBox.UseVisualStyleBackColor = true;
            this.muteSpecificSoundCheckBox.CheckedChanged += new System.EventHandler(this.muteSpecificSoundCheckBox_CheckedChanged);
            // 
            // speciaSoundOptionsComboBox
            // 
            this.speciaSoundOptionsComboBox.FormattingEnabled = true;
            this.speciaSoundOptionsComboBox.Items.AddRange(new object[] {
            "Animasyon Sesi",
            "Puan Ekleme Sesi",
            "Zaman Bitti Sesi",
            "Zaman Biplemesi"});
            this.speciaSoundOptionsComboBox.Location = new System.Drawing.Point(7, 20);
            this.speciaSoundOptionsComboBox.Name = "speciaSoundOptionsComboBox";
            this.speciaSoundOptionsComboBox.Size = new System.Drawing.Size(185, 21);
            this.speciaSoundOptionsComboBox.TabIndex = 0;
            this.speciaSoundOptionsComboBox.SelectedIndexChanged += new System.EventHandler(this.speciaSoundOptionsComboBox_SelectedIndexChanged);
            // 
            // generalSoundSettingsGroupBox
            // 
            this.generalSoundSettingsGroupBox.Controls.Add(this.muteRadioButton);
            this.generalSoundSettingsGroupBox.Controls.Add(this.useSpecialRadioButton);
            this.generalSoundSettingsGroupBox.Controls.Add(this.useBeepsRadioButton);
            this.generalSoundSettingsGroupBox.Controls.Add(this.useDefaultSoundsRadioButton);
            this.generalSoundSettingsGroupBox.Location = new System.Drawing.Point(3, 8);
            this.generalSoundSettingsGroupBox.Name = "generalSoundSettingsGroupBox";
            this.generalSoundSettingsGroupBox.Size = new System.Drawing.Size(212, 175);
            this.generalSoundSettingsGroupBox.TabIndex = 0;
            this.generalSoundSettingsGroupBox.TabStop = false;
            this.generalSoundSettingsGroupBox.Text = "Genel";
            // 
            // muteRadioButton
            // 
            this.muteRadioButton.AutoSize = true;
            this.muteRadioButton.Location = new System.Drawing.Point(6, 91);
            this.muteRadioButton.Name = "muteRadioButton";
            this.muteRadioButton.Size = new System.Drawing.Size(62, 17);
            this.muteRadioButton.TabIndex = 3;
            this.muteRadioButton.TabStop = true;
            this.muteRadioButton.Text = "Sesi Kıs";
            this.muteRadioButton.UseVisualStyleBackColor = true;
            this.muteRadioButton.CheckedChanged += new System.EventHandler(this.muteRadioButton_CheckedChanged);
            // 
            // useSpecialRadioButton
            // 
            this.useSpecialRadioButton.AutoSize = true;
            this.useSpecialRadioButton.Location = new System.Drawing.Point(6, 67);
            this.useSpecialRadioButton.Name = "useSpecialRadioButton";
            this.useSpecialRadioButton.Size = new System.Drawing.Size(99, 17);
            this.useSpecialRadioButton.TabIndex = 2;
            this.useSpecialRadioButton.TabStop = true;
            this.useSpecialRadioButton.Text = "Özel Ses Kullan";
            this.useSpecialRadioButton.UseVisualStyleBackColor = true;
            this.useSpecialRadioButton.CheckedChanged += new System.EventHandler(this.useSpecialRadioButton_CheckedChanged);
            // 
            // useBeepsRadioButton
            // 
            this.useBeepsRadioButton.AutoSize = true;
            this.useBeepsRadioButton.Location = new System.Drawing.Point(6, 43);
            this.useBeepsRadioButton.Name = "useBeepsRadioButton";
            this.useBeepsRadioButton.Size = new System.Drawing.Size(201, 17);
            this.useBeepsRadioButton.TabIndex = 1;
            this.useBeepsRadioButton.TabStop = true;
            this.useBeepsRadioButton.Text = "Anakart Hapörlörünü Kullan (Bipleme)";
            this.useBeepsRadioButton.UseVisualStyleBackColor = true;
            this.useBeepsRadioButton.CheckedChanged += new System.EventHandler(this.useBeepsRadioButton_CheckedChanged);
            // 
            // useDefaultSoundsRadioButton
            // 
            this.useDefaultSoundsRadioButton.AutoSize = true;
            this.useDefaultSoundsRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.useDefaultSoundsRadioButton.Location = new System.Drawing.Point(6, 19);
            this.useDefaultSoundsRadioButton.Name = "useDefaultSoundsRadioButton";
            this.useDefaultSoundsRadioButton.Size = new System.Drawing.Size(107, 17);
            this.useDefaultSoundsRadioButton.TabIndex = 0;
            this.useDefaultSoundsRadioButton.TabStop = true;
            this.useDefaultSoundsRadioButton.Text = "Varsayılanı Kullan";
            this.useDefaultSoundsRadioButton.UseVisualStyleBackColor = true;
            this.useDefaultSoundsRadioButton.CheckedChanged += new System.EventHandler(this.useDefaultSoundsRadioButton_CheckedChanged);
            // 
            // applyButton
            // 
            this.applyButton.Image = ((System.Drawing.Image)(resources.GetObject("applyButton.Image")));
            this.applyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyButton.Location = new System.Drawing.Point(287, 221);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Uygula";
            this.applyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // okButton
            // 
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(368, 221);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Tamam";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(206, 221);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "İptal";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openSound
            // 
            this.openSound.FileName = "openFileDialog1";
            this.openSound.Filter = "WAV Dosyası|*.wav";
            // 
            // openPrePreparedGame
            // 
            this.openPrePreparedGame.FileName = "*.bkbi";
            this.openPrePreparedGame.Filter = "Hazır Oyun|*.bkbi";
            // 
            // settingsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 256);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.settingTabsTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsGUI";
            this.Text = "Ayarlar";
            this.generalTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.prePreparedGameGroupBox.ResumeLayout(false);
            this.prePreparedGameGroupBox.PerformLayout();
            this.autoPrePreparedGameGroupBox.ResumeLayout(false);
            this.autoPrePreparedGameGroupBox.PerformLayout();
            this.ArduinoGroupBox.ResumeLayout(false);
            this.ArduinoGroupBox.PerformLayout();
            this.settingTabsTabControl.ResumeLayout(false);
            this.soundTabPage.ResumeLayout(false);
            this.SoundGroupBox.ResumeLayout(false);
            this.SoundGroupBox.PerformLayout();
            this.specialBox.ResumeLayout(false);
            this.specialBox.PerformLayout();
            this.generalSoundSettingsGroupBox.ResumeLayout(false);
            this.generalSoundSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.GroupBox prePreparedGameGroupBox;
        private System.Windows.Forms.GroupBox autoPrePreparedGameGroupBox;
        private System.Windows.Forms.TextBox autoPrePreparedGamePathTextBox;
        private System.Windows.Forms.Button browseGamesButton;
        private System.Windows.Forms.CheckBox useAutoPrePreparedGame;
        private System.Windows.Forms.CheckBox usePrePreparedSettingsFromPrePreparedGamesChechBox;
        private System.Windows.Forms.GroupBox ArduinoGroupBox;
        private System.Windows.Forms.Button arduinoCodeShowButton;
        private System.Windows.Forms.Label ArduinoPortLabel;
        private System.Windows.Forms.TextBox arduinoPortBox;
        private System.Windows.Forms.CheckBox useArduinoIntegrationCheckBox;
        private System.Windows.Forms.TabControl settingTabsTabControl;
        private System.Windows.Forms.TabPage soundTabPage;
        private System.Windows.Forms.GroupBox SoundGroupBox;
        private System.Windows.Forms.TextBox soundPathTextBlx;
        private System.Windows.Forms.CheckBox muteSpecificSoundCheckBox;
        private System.Windows.Forms.ComboBox speciaSoundOptionsComboBox;
        private System.Windows.Forms.GroupBox generalSoundSettingsGroupBox;
        private System.Windows.Forms.RadioButton useSpecialRadioButton;
        private System.Windows.Forms.RadioButton useBeepsRadioButton;
        private System.Windows.Forms.RadioButton useDefaultSoundsRadioButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button browseSoundsButton;
        private System.Windows.Forms.RadioButton muteRadioButton;
        private System.Windows.Forms.OpenFileDialog openSound;
        private System.Windows.Forms.OpenFileDialog openPrePreparedGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox specialBox;
    }
}