using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bkbi.Forms.ControlPanel.PlayerUI
{
    public partial class changeNameForm : Form
    {

        int Id;
        Core.Player p;

        public changeNameForm(int id)
        {
            InitializeComponent();
            Id = id;
            p = Core.Player.GetById(Id);

            textBox1.Text = p.Name;
            label1.Text = System.Text.RegularExpressions.Regex.Replace(label1.Text, @"%x", Id.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.setName(textBox1.Text);
            Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Select(0, textBox1.TextLength);
        }
    }
}
