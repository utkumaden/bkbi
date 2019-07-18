using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace bkbi.Forms.ControlPanel.PlayerUI
{
    public partial class pointsMenuForm : Form
    {

        int Id;
        Core.Player p;

        public pointsMenuForm(int id)
        {
            InitializeComponent();

            Id = id;
            p = Core.Player.GetById(Id);

            label1.Text = Regex.Replace(label1.Text, "%x", Id.ToString());
            label1.Text = Regex.Replace(label1.Text, @"\b%a\b", p.Name);
            label1.Text = Regex.Replace(label1.Text, @"\b%p\b", p.Points.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                p.addPoints((uint)numericUpDown1.Value);
            }
            else if (radioButton2.Checked)
            {
                p.deductPoints((uint)numericUpDown1.Value);
            }
            Close();
        }
    }
}
