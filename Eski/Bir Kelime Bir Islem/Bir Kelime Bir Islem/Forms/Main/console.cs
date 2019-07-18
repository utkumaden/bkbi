using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms.Main
{
    public partial class console : Form
    {
        public console()
        {
            InitializeComponent();
            FormClosing += Console_FormClosing;
            inbox.Focus();
        }

        private void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; 
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }
    }
}
