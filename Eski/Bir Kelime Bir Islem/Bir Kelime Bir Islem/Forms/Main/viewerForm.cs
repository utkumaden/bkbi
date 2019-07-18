using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms
{
    public partial class viewerForm : Form
    {

        public viewerForm()
        {
            InitializeComponent();
            //Program.mainform.enabler();
        }

        private void doubleClick(object sender, MouseEventArgs e)
        {
            menu.Show();
        }

        private void P1pm_VisibleChanged(object sender, EventArgs e)
        {
            if (P1plus.Visible) P1plus.Visible = false;
            else P1plus.Visible = true;
        }

        private void P2pm_VisibleChanged(object sender, EventArgs e)
        {
            if (P2plus.Visible) P2plus.Visible = false;
            else P2plus.Visible = true;
        }

        private void P3pm_VisibleChanged(object sender, EventArgs e)
        {
            if (P3plus.Visible) P3plus.Visible = false;
            else P3plus.Visible = true;
        }

        private void viewerForm_Load(object sender, EventArgs e)
        {
            controlForm.P1.updateParams(P1Points, P1pm, P1plus, panel1, P1name);
            controlForm.P2.updateParams(P2Points, P2pm, P2plus, panel2, P2name);
            controlForm.P3.updateParams(P3Points, P3pm, P3plus, panel3, P3name);
            Program.mainform.hideAll();
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close();
        }
        
        public void hideQuestion()
        {

        }

        public void timeRanOut()
        {

        }
    }
}
