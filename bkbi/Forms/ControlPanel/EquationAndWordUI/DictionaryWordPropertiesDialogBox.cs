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
    public partial class DictionaryWordPropertiesDialogBox : Form
    {

        int Id;

        public DictionaryWordPropertiesDialogBox(int id)
        {
            InitializeComponent();
            Id = id;
            numericUpDown1.Value = Core.Questions.GetById(Id).MaximumWorthInPoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text))
            {
                if(textBox1.Text !="<eskisi>")Core.DictionaryWord.changeDictionary(textBox1.Text);
                Core.Questions.GetById(Id).SetWorth((uint)numericUpDown1.Value);
                Close();
            }
            else
            {
                MessageBox.Show("Dosya Yok ya da hatalı seçim");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
