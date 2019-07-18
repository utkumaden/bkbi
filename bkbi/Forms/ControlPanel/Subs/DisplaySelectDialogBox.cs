using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace bkbi.Forms.ControlPanel.Subs
{
    public partial class DisplaySelectDialogBox : Form
    {

        public readonly string template = "%x: %i (%r|%e)";

        public DisplaySelectDialogBox()
        {
            InitializeComponent();

            foreach(var screen in Screen.AllScreens)
            {
                comboBox1.Items.Add(screen.DeviceName);
            }
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            Core.Threads.ViewerPanelThread = new Thread(new ThreadStart(() =>
            {
                ViewerPanel.ViewerPanel v = new ViewerPanel.ViewerPanel();
                v.WindowState = FormWindowState.Normal;
                v.Location = Screen.AllScreens[i].WorkingArea.Location;
                v.WindowState = FormWindowState.Maximized;
                Core.Threads.ViewerPanel = v;
                Application.Run(v);
            }));
            Core.Threads.ViewerPanelThread.Start();
            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
