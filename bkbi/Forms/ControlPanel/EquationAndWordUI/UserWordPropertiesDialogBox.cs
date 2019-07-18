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
    public partial class UserWordPropertiesDialogBox : Form
    {

        int Id;

        public UserWordPropertiesDialogBox(int id)
        {
            InitializeComponent();

            Id = id;
            Core.UserWord x = Core.Questions.GetById(Id) as Core.UserWord;
            textBox1.Text = x.Word;
            numericUpDown1.Value = x.MaximumWorthInPoints;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Core.UserWord x = Core.Questions.GetById(Id) as Core.UserWord;
            x.setUserWord(textBox1.Text);
            x.SetWorth((uint)numericUpDown1.Value);
            Close();
        }
    }
}
