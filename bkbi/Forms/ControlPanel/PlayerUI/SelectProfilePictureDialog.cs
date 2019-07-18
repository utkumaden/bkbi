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
    public partial class SelectProfilePictureDialog : Form
    {
        int Id;
        Core.Player p;

        public SelectProfilePictureDialog(int id)
        {
            InitializeComponent();

            Id = id;
            p =Core.Player.GetById(Id);

            label1.Text = label1.Text.Replace("%o", Id.ToString());
            pictureBox1.Image = p.PlayerIcon;
            textBox1.Text = "<Eskisi>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "<Eskisi>") Close();
            else if (System.IO.File.Exists(textBox1.Text))
            {
                p.setPP(new Bitmap(textBox1.Text));
                Close();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir dosya yolu girin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
