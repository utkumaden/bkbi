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
    public partial class viewerWindowPlacer : Form
    {
        static bool iShown = false;

        public viewerWindowPlacer()
        {
            InitializeComponent();
        }

        private void MonitorSelect(object sender, EventArgs e)
        {
            if (iShown)
            {
                int[] pos = { 0, 0 };
                pos[0] = MousePosition.X;
                pos[1] = MousePosition.Y;
                if (!controlForm.vForm.IsDisposed) controlForm.vForm.Dispose();
                if (controlForm.vForm.IsDisposed)
                {
                    controlForm.vForm = new viewerForm();
                }
                controlForm.vForm.Location = new Point(pos[0], pos[1]);                
                controlForm.vForm.Show();
                Close();
            }
            
        }

        private void shownEvent(object sender, EventArgs e)
        {
            Focus();
            iShown = true;
        }
    }
}
