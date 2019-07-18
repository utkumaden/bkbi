using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bkbi.Forms.ControlPanel.EquationAndWordUI
{
    public partial class UserEquationPropertiesDialogBox : Form
    {
        int Id;

        public UserEquationPropertiesDialogBox(int id)
        {
            InitializeComponent();
            Id = id;

            Core.UserEquation x = Core.Questions.GetById(Id) as Core.UserEquation;
            a.Text = x.numbers[0].ToString();
            b.Text = x.numbers[1].ToString();
            c.Text = x.numbers[2].ToString();
            d.Text = x.numbers[3].ToString();
            e.Text = x.numbers[4].ToString();
            f.Text = x.numbers[5].ToString();
            sum.Text = x.sum.ToString();
            solve.Text = x.solve;
            numericUpDown1.Value = x.MaximumWorthInPoints;
        }

        private void a_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if(t.MaxLength <= t.Text.Length)
            {
                if (t.Tag == a.Tag) b.Focus();
                else if (t.Tag == b.Tag) c.Focus();
                else if (t.Tag == c.Tag) d.Focus();
                else if (t.Tag == d.Tag) this.e.Focus();
                else if (t.Tag == this.e.Tag) f.Focus();
                else if (t.Tag == f.Tag) sum.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Core.UserEquation eq = Core.Questions.GetById(Id) as Core.UserEquation;
            int[] nums = new int[] 
            {
                int.Parse(a.Text),
                int.Parse(b.Text),
                int.Parse(c.Text),
                int.Parse(d.Text),
                int.Parse(this.e.Text),
                int.Parse(f.Text)
            };
            string solv = solve.Text;
            int sm = int.Parse(sum.Text);
            eq.set(sm, solv, nums);
            eq.SetWorth((uint)numericUpDown1.Value);
            Close();
        }
    }
}
