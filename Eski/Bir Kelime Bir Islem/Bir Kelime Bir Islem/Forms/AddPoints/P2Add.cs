using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms.AddPoints
{
    public partial class P2Add : Form
    {
        public P2Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                controlForm.P2.addPoints(Int32.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Lütfen Sayı Girin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();

        }

        private void P2Add_Load(object sender, EventArgs e)
        {
            Focus();
            textBox1.Focus();
            textBox1.SelectAll();
            textBox1.SelectionStart = 0;
            textBox1.Select();
        }
    }
}
