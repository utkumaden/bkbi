using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bir_Kelime_Bir_Islem.Forms
{
    public partial class itemShow : Form
    {

        public itemShow(string item)
        {
            InitializeComponent();
            label1.Text = item;
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
