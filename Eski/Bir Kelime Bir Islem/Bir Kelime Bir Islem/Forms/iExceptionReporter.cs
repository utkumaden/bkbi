using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms
{
    public partial class iExceptionReporter : Form
    {
        public iExceptionReporter(string message)
        {
            InitializeComponent();

            exceptionMessage.Text = message;
            exceptionDetails.Visible = false;
        }

        public iExceptionReporter(string message, string title)
        {
            InitializeComponent();

            exceptionMessage.Text = message;
            this.Text = title;
            exceptionDetails.Visible = false;
        }

        public iExceptionReporter(string message, string title, Exception ex)
        {
            InitializeComponent();

            exceptionMessage.Text = message;
            this.Text = title;
            exceptionDetails.Text = ex.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
