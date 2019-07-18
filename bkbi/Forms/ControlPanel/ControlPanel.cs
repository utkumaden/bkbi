using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace bkbi.Forms.ControlPanel
{
    public partial class ControlPanel : Form
    {

        System.Timers.Timer TimeUpdater = new System.Timers.Timer();

        public ControlPanel()
        {
            InitializeComponent();

            Core.Timing.init();

            TimeUpdater.Interval = 100;
            TimeUpdater.Elapsed += TimeUpdate;
            TimeUpdater.Start();
        }

        private void TimeUpdate(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(!IsDisposed) Invoke(((MethodInvoker)
            (
                () =>
                {
                    if (!timeBar.IsDisposed || !timeLabel.IsDisposed|| !IsDisposed)
                    {
                        timeBar.Maximum = Core.Timing.StartLenght;
                        if (Core.Timing.TimeNow != -1)
                        {
                            timeBar.Style = ProgressBarStyle.Continuous;
                            timeBar.Value = Core.Timing.TimeNow;
                            timeLabel.Text = Core.Timing.TimeNow.ToString() + "/" + Core.Timing.StartLenght;
                        }
                        else
                        {
                            timeBar.Value = 1;
                            timeBar.Style = ProgressBarStyle.Marquee;
                            timeLabel.Text = "###";
                        }
                    }
                    else return;
                }
            )
            ));
            Invoke(((MethodInvoker) (() =>
            {
                if (manuelButtonsButton.Checked)
                {
                    autoButtonsGroupBox.Enabled = false;
                }
                else
                {
                    autoButtonsGroupBox.Enabled = true;
                }
                if (SendRandomCheckBox.Checked)
                {
                    numericUpDown3.Enabled = false;
                }
                else
                {
                    numericUpDown3.Enabled = true;
                }
                A.Text = ViewerPanel.ViewerClass.viewChars[0].ToString();
                B.Text = ViewerPanel.ViewerClass.viewChars[1].ToString();
                C.Text = ViewerPanel.ViewerClass.viewChars[2].ToString();
                D.Text = ViewerPanel.ViewerClass.viewChars[3].ToString();
                E.Text = ViewerPanel.ViewerClass.viewChars[4].ToString();
                F.Text = ViewerPanel.ViewerClass.viewChars[5].ToString();
                G.Text = ViewerPanel.ViewerClass.viewChars[6].ToString();
                H.Text = ViewerPanel.ViewerClass.viewChars[7].ToString();
            })));
        }

        private void oyuncuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playersListViewBox.Items.Add( new Core.Player().menuItem );
        }

        private void playerContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if(playersListViewBox.FocusedItem == null)
            {
                toolStripSeparator2.Visible = false;
                changeNameToolStripMenuItem.Visible = false;
                puanMenüsüToolStripMenuItem.Visible = false;
                oyundaToolStripMenuItem.Visible = false;
                resimToolStripMenuItem.Visible = false;
                oyuncuyuSilToolStripMenuItem.Visible = false;
            }
            else
            {
                toolStripSeparator2.Visible = true;
                changeNameToolStripMenuItem.Visible = true;
                puanMenüsüToolStripMenuItem.Visible = true;
                oyundaToolStripMenuItem.Visible = true;
                int i = playerIdFind();
                if (i != -1) oyundaToolStripMenuItem.Checked = Core.Player.GetById(playerIdFind()).inGame;
                else oyundaToolStripMenuItem.CheckState = CheckState.Indeterminate;
                resimToolStripMenuItem.Visible = true;
                oyuncuyuSilToolStripMenuItem.Visible = true;
            }
        }

        private void eqAndWordContectMenu_Opening(object sender, CancelEventArgs e)
        {
            if (eqAndWordsListViewBox.FocusedItem == null)
            {
                kaldırToolStripMenuItem.Visible = false;
                özelliklerToolStripMenuItem.Visible = false;
                seçToolStripMenuItem.Visible = false;
                toolStripSeparator3.Visible = false;
            }
            else
            {
                kaldırToolStripMenuItem.Visible = true;
                özelliklerToolStripMenuItem.Visible = true;
                seçToolStripMenuItem.Visible = true;
                toolStripSeparator3.Visible = true;
            }
        }


        int playerIdFind()
        {
            if(playersListViewBox.FocusedItem != null)
            {
                return int.Parse(playersListViewBox.FocusedItem.Text);
            }
            else
            {
                return -1;
            }
        }

        int eqOrWordIdFind()
        {
            if (eqAndWordsListViewBox.FocusedItem != null)
            {
                return int.Parse(eqAndWordsListViewBox.FocusedItem.Text);
            }
            else
            {
                return -1;
            }
        }

        private void adıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PlayerUI.changeNameForm(playerIdFind()).Show();
        }

        private void puanMenüsüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PlayerUI.pointsMenuForm(playerIdFind()).Show();
        }

        private void oyundaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {

            Core.Player p = Core.Player.GetById(playerIdFind());

            if ((sender as ToolStripMenuItem).Checked)
            {
                p.setInGame(true);
            }
            else
            {
                p.setInGame(false);
            }
        }

        private void oyuncuyuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Oyuncuyu silmek istediğinizden emin misiniz?", "Oyuncuyu Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r== DialogResult.Yes)
            {
                Core.Player.GetById(playerIdFind()).Remove();
            }
        }

        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.Questions a = Core.Questions.GetById(eqOrWordIdFind());
            DialogResult r = MessageBox.Show("Kelimeyi ya da İşlemi Silmek istediğinizden emin misiniz?", "Kelimeyi ya da İşlemi Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                a.Remove();
            }
        }

        private void karışıkKelimeSözlükGerektirirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eqAndWordsListViewBox.Items.Add(new Core.DictionaryWord().menuItem);
        }

        private void özelliklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Core.Questions.GetById(eqOrWordIdFind()).Type)
            {
                case Core.Questions.TypeEnum.AutoEquation:
                    MessageBox.Show("Otomatik işlemde doğruluk garantisi verilmez! Ayrıca bu ögenin özellikleri yok.", "Otomatik İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Core.Questions.TypeEnum.DictionaryWord:
                    new EquationAndWordUI.DictionaryWordPropertiesDialogBox(eqOrWordIdFind()).Show();
                    break;
                case Core.Questions.TypeEnum.UserEquation:
                    new EquationAndWordUI.UserEquationPropertiesDialogBox(eqOrWordIdFind()).Show();
                    break;
                case Core.Questions.TypeEnum.UserWord:
                    new EquationAndWordUI.UserWordPropertiesDialogBox(eqOrWordIdFind()).Show();
                    break;
            }
        }

        private void hazırİşlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eqAndWordsListViewBox.Items.Add(new Core.UserEquation().menuItem);
        }

        private void hazırKelimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eqAndWordsListViewBox.Items.Add(new Core.UserWord().menuItem);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            new Subs.DisplaySelectDialogBox().ShowDialog();
        }

        private void seçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = Core.Questions.GetById(eqOrWordIdFind()).Id;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Core.Questions eaw = Core.Questions.GetById((int)numericUpDown3.Value);
            foreach(Core.Questions a in Core.Questions.All)
            {
                a.menuItem.ForeColor = SystemColors.WindowText;
            }
            if(eaw != null) eaw.menuItem.ForeColor = Color.DarkGreen;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Core.Threads.ViewerPanelThread.Abort();
            }
            catch
            {
                MessageBox.Show("Açık Olmayan pencereyi kapatamazsınız.");
            }
        }

        private void showNextButton_Click(object sender, EventArgs e)
        {
            if (SendRandomCheckBox.Checked)
            {
                SendItem(Core.Questions.All[new Random().Next(0, Core.Questions.All.Count)]);
            }
            else
            {
                if (numericUpDown3.Value == 0) SendItem(Core.Questions.All[new Random().Next(0, Core.Questions.All.Count)]);
                else
                {
                    try
                    {
                        SendItem(Core.Questions.All[(int)numericUpDown3.Value - 1]);
                    }
                    catch (IndexOutOfRangeException ex)
                    { }
                }
            }
        }

        internal void SendItem(Core.Questions eq)
        {            
            ViewerPanel.ViewerClass.setup(eq);            
        }

        private void resimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PlayerUI.SelectProfilePictureDialog(playerIdFind()).Show();
        }

        private void startCountdownTImerButton_Click(object sender, EventArgs e)
        {
            Core.Timing.StartTimer();
        }

        private void stopCountdownTimerButton_Click(object sender, EventArgs e)
        {
            Core.Timing.StopTimer();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Core.Timing.StartLenght = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Core.Timing.AlarmLenght = (int)numericUpDown2.Value;
        }

        private void consoleRichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.Select(rtb.TextLength - 1, 1);
            rtb.ScrollToCaret();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = openGameOpenFileDialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                try
                {
                    Core.SaveLoad.Load(openGameOpenFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    Tools.Console.Error(ex.ToString());
                    MessageBox.Show("Oyun Yüklenirken hata oldu.\n" + ex.ToString(), "Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
            TimeUpdater.Stop();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new about().Show();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = saveFileDialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                Core.SaveLoad.Save(saveFileDialog.FileName);
            }
        }

        private void buttonsPressButtom_Click(object sender, EventArgs e)
        {
            new Subs.buttonPressForm().Show();
        }
    }
}
