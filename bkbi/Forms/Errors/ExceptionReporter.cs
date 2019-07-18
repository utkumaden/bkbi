using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace bkbi.Forms.Errors
{
    public partial class ExceptionReporter : Form
    {

        Exception exVar;
        int time;
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        delegate void delegatevoid();        

        public ExceptionReporter(Exception ex, int timeout)
        {
            InitializeComponent();
            exVar = ex;

            if (ex.Message != null) exViewer.Rows.Add(new object[] { "İleti", ex.Message });
            if (ex.HelpLink != null) exViewer.Rows.Add(new object[] { "Yardım Linki", ex.HelpLink });
            if (ex.HResult != null) exViewer.Rows.Add(new object[] { "HResult", ex.HResult });
            if (ex.InnerException != null) exViewer.Rows.Add(new object[] { "İç İstisna", ex.InnerException });
            if (ex.Source != null) exViewer.Rows.Add(new object[] { "Kaynak", ex.Source });
            if (ex.StackTrace != null) exViewer.Rows.Add(new object[] { "Yığın", ex.StackTrace });
            if (ex.TargetSite != null) exViewer.Rows.Add(new object[] { "Olay Mahali", ex.TargetSite });

            time = timeout;
            timeBar.Maximum = timeout;
            timeLabel.Text = timeout.ToString();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            Invoke(new delegatevoid(timeUpt));
            if (time == 0) { timer.Stop(); Invoke(new delegatevoid(() => Close())); return; }
            time--;
        }

        public void timeUpt()
        {
            timeLabel.Text = time.ToString();
            timeBar.Value = time;
        }        

        void stopCountDown()
        {
            timer.Stop();
            timeMsgLabel1.Enabled = false;
            timeLabel.Enabled = false;
            timeMsgLabel2.Enabled = false;
            timeBar.Enabled = false;
            cntdwnStop.Enabled = false;
        }

        private void cntdwnStop_Click(object sender, EventArgs e)
        {
            stopCountDown();
        }

        private void saveInf_Click(object sender, EventArgs e)
        {
            stopCountDown();
            DialogResult r = saveCrashReportDialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                XmlDocument doc = reportPreparer();
                doc.Save(saveCrashReportDialog.FileName);
            }
        }

        XmlDocument reportPreparer()
        {
            XmlDocument toReturn = new XmlDocument();
            XmlNode rootNode = toReturn.CreateElement("errorReport");
            XmlNode exceptionNode = toReturn.CreateElement("exception");
            XmlNode logNode = toReturn.CreateElement("log");
            rootNode.AppendChild(exceptionNode);
            rootNode.AppendChild(logNode);
            toReturn.AppendChild(rootNode);


            if (exVar.Message != null)
            {
                XmlNode x = toReturn.CreateElement("message");
                x.InnerText = exVar.Message;
                exceptionNode.AppendChild(x);
            }
            if (exVar.HelpLink != null)
            {
                XmlNode x = toReturn.CreateElement("helpLink");
                x.InnerText = exVar.HelpLink;
                exceptionNode.AppendChild(x);
            }
            if (exVar.HResult != null)
            {
                XmlNode x = toReturn.CreateElement("HResult");
                x.InnerText = exVar.HResult.ToString();
                exceptionNode.AppendChild(x);
            }
            if (exVar.InnerException != null)
            {
                XmlNode x = toReturn.CreateElement("innerException");
                x.InnerText = exVar.InnerException.ToString();
                exceptionNode.AppendChild(x);
            }
            if (exVar.Source != null)
            {
                XmlNode x = toReturn.CreateElement("source");
                x.InnerText = exVar.Source;
                exceptionNode.AppendChild(x);
            }
            if (exVar.StackTrace != null)
            {
                XmlNode x = toReturn.CreateElement("stackTrace");
                x.InnerText = exVar.StackTrace;
                exceptionNode.AppendChild(x);
            }
            if (exVar.TargetSite != null)
            {
                XmlNode x = toReturn.CreateElement("targetSite");
                x.InnerText = exVar.TargetSite.ToString();
                exceptionNode.AppendChild(x);
            }

            //TODO: Add log to the error report


            return toReturn;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath, string.Join(" ", Environment.GetCommandLineArgs().ToList().GetRange(1, Environment.GetCommandLineArgs().Length-1))); // to start new instance of application
            Environment.Exit(1);
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }

}
