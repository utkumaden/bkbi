using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bkbi.Forms.ControlPanel.Subs
{
    public partial class buttonPressForm : Form
    {
        public buttonPressForm()
        {
            InitializeComponent();
            Core.Timing.Pause();
            foreach(Core.Player p in Core.Player.All)
            {
                playersListViewBox.Items.Add((ListViewItem)p.menuItem.Clone());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.ControlPanel.AutoPointsCheckBox.Checked)
            {
                Core.Player.GetById(playerIdFind()).addPoints((uint)Core.Questions.GetDeltaWorth((int)ViewerPanel.ViewerClass.currentPoints, (int)Core.Timing.TimeNow, (int)Core.Timing.StartLenght));
            }
            Core.Timing.Pause(false);
            Core.Timing.StopTimer();
            Close();
        }

        int playerIdFind()
        {
            if (playersListViewBox.FocusedItem != null)
            {
                return int.Parse(playersListViewBox.FocusedItem.Text);
            }
            else
            {
                return -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Core.Timing.Pause(false);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.ControlPanel.AutoPointsCheckBox.Checked)
            {
                Core.Player Z = Core.Player.GetById(playerIdFind());
                foreach (Core.Player p in Core.Player.All)
                {
                    if(p != Z) p.addPoints((uint)(ViewerPanel.ViewerClass.currentPoints/2));
                }
            }
            Core.Timing.Pause(false);
            Core.Timing.StopTimer();
            Close();
        }
    }
}
