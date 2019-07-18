using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms.Main
{
    public partial class settingsGUI : Form
    {
        string[] soundpaths = { "", "", "" ,"" };
        bool[] soundMutes = { false, false, false, false };
        bool close = false;
        setting settings = controlForm.settings;
        public settingsGUI()
        {
            InitializeComponent();
            useArduinoIntegrationCheckBox.Checked = settings.getUseArduino();
            arduinoPortBox.Text = settings.getArduinoPort();
            usePrePreparedSettingsFromPrePreparedGamesChechBox.Checked = settings.getUseSettingsFromGames();
            useAutoPrePreparedGame.Checked = settings.getUseAutoGames();
            autoPrePreparedGamePathTextBox.Text = settings.getAutoGamePath();
            if (settings.getSoundType() == 0)
            {
                useDefaultSoundsRadioButton.Checked = true;
            }
            if (settings.getSoundType() == 1)
            {
                useBeepsRadioButton.Checked = true;
            }
            if (settings.getSoundType() == 2)
            {
                useSpecialRadioButton.Checked = true;
            }
            if (settings.getSoundType() == 3)
            {
                muteRadioButton.Checked = true;
            }
            timeBox.Text = settings.getTime().ToString();
            soundMutes = settings.getMuteThis();
            soundpaths = settings.getSoundPath();
        }

        private void speciaSoundOptionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciaSoundOptionsComboBox.Text == "Animasyon Sesi") onAnimeSwitch();
            if (speciaSoundOptionsComboBox.Text == "Puan Ekleme Sesi") onAddSwitch();
            if (speciaSoundOptionsComboBox.Text == "Zaman Bitti Sesi") onTimeSwitch();
            if (speciaSoundOptionsComboBox.Text == "Zaman Biplemesi") onBeepSwitch();
        }

        private void useDefaultSoundsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            specialBox.Enabled = false;
        }

        private void useBeepsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            specialBox.Enabled = false;
        }

        private void useSpecialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            specialBox.Enabled = true;
        }

        private void muteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            specialBox.Enabled = false;
        }

        private void muteSpecificSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(speciaSoundOptionsComboBox.Text == "Animasyon Sesi")
            {
                soundMutes[0] = muteSpecificSoundCheckBox.Checked;
            }
            if (speciaSoundOptionsComboBox.Text == "Puan Ekleme Sesi")
            {
                soundMutes[1] = muteSpecificSoundCheckBox.Checked;
            }
            if(speciaSoundOptionsComboBox.Text == "Zaman Bitti Sesi")
            {
                soundMutes[2] = muteSpecificSoundCheckBox.Checked;
            }
            if (speciaSoundOptionsComboBox.Text == "Zaman Biplemesi")
            {
                soundMutes[3] = muteSpecificSoundCheckBox.Checked;
            }
        }

        private void soundPathTextBlx_TextChanged(object sender, EventArgs e)
        {
            if (speciaSoundOptionsComboBox.Text == "Harf Gelme")
            {
                soundpaths[0] = (sender as TextBox).Text;
            }
            if (speciaSoundOptionsComboBox.Text == "Puan Ekleme")
            {
                soundpaths[1] = (sender as TextBox).Text;
            }
        }

        void save()
        {
            settings.setArduinoPort(arduinoPortBox.Text);
            settings.setUseArduino(useArduinoIntegrationCheckBox.Checked);
            settings.setAutoGamePath(autoPrePreparedGamePathTextBox.Text);
            settings.setUseAutoGames(useAutoPrePreparedGame.Checked);
            settings.setUseSettingsFromGames(usePrePreparedSettingsFromPrePreparedGamesChechBox.Checked);
            int i;
            if (useDefaultSoundsRadioButton.Checked) i = 0;
            else if (useBeepsRadioButton.Checked) i = 1;
            else if (useSpecialRadioButton.Checked) i = 2;
            else i = 3;
            settings.setSoundType(i);
            settings.setSoundPath(soundpaths);
            settings.setMuteThis(soundMutes);
            settings.setTime(int.Parse(timeBox.Text));
            settings.updateSettings();
            if (close) Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            close = false;
            save();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            close = true;
            save();
        }

        void onAnimeSwitch()
        {
            muteSpecificSoundCheckBox.Checked = soundMutes[0];
            soundPathTextBlx.Text = soundpaths[0];
        }

        void onAddSwitch()
        {
            muteSpecificSoundCheckBox.Checked = soundMutes[1];
            soundPathTextBlx.Text = soundpaths[1];
        }

        void onTimeSwitch()
        {
            muteSpecificSoundCheckBox.Checked = soundMutes[2];
            soundPathTextBlx.Text = soundpaths[2];
        }

        void onBeepSwitch()
        {
            muteSpecificSoundCheckBox.Checked = soundMutes[3];
            soundPathTextBlx.Text = soundpaths[3];
        }

        void pathman()
        {
            DialogResult r = openSound.ShowDialog();
            if (r == DialogResult.Cancel) return;
            if (speciaSoundOptionsComboBox.Text == "Animasyon Sesi")
            {
                soundpaths[0] = openSound.FileName;
                soundPathTextBlx.Text = soundpaths[0];
            }
            if (speciaSoundOptionsComboBox.Text == "Puan Ekleme Sesi")
            {
                soundpaths[1] = openSound.FileName;
                soundPathTextBlx.Text = soundpaths[1];
            }
            if (speciaSoundOptionsComboBox.Text == "Zaman Bitti Sesi")
            {
                soundpaths[2] = openSound.FileName;
                soundPathTextBlx.Text = soundpaths[2];
            }
            if(speciaSoundOptionsComboBox.Text == "Zaman Biplemesi")
            {
                soundpaths[3] = openSound.FileName;
                soundPathTextBlx.Text = soundpaths[3];
            }
        }

        private void browseSoundsButton_Click(object sender, EventArgs e)
        {
            pathman();
        }

        private void browseGamesButton_Click(object sender, EventArgs e)
        {
            openPrePreparedGame.ShowDialog();
            autoPrePreparedGamePathTextBox.Text = openPrePreparedGame.FileName;
        }
    }
}
