using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Bir_Kelime_Bir_Islem.Forms
{
    class timeKeeping
    {
        private Timer defaultT = new Timer();
        private Timer defaultcolorizer= new Timer();
        private Timer buttoncolorizer = new Timer();
        private object iSender;
        int timeSec;
        bool alreadyDone;
        delegate void d(object sender, ElapsedEventArgs e);
        delegate void dd();
        public bool availiable = false;

        public timeKeeping()
        {
            defaultT.Elapsed += DefaultT_Elapsed;
            defaultcolorizer.Elapsed += Defaultcolorizer_Elapsed;
            buttoncolorizer.Elapsed += Buttoncolorizer_Elapsed;
        }

        private void Buttoncolorizer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Defaultcolorizer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
        }

        private void DefaultT_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (controlForm.vForm.timeLabel.InvokeRequired) controlForm.vForm.Invoke(new d(DefaultT_Elapsed), new object[] { null, null });
            else
            {
                if (int.Parse(controlForm.vForm.timeLabel.Text) <= 5 && !alreadyDone)
                {
                    defaultcolorizer.Interval = 500;
                    defaultcolorizer.Start();
                }
                if (controlForm.vForm.timeLabel.Text == "0")
                {
                    timeStop();
                }
                else
                {
                    controlForm.vForm.timeLabel.Text = (int.Parse(controlForm.vForm.timeLabel.Text) - 1).ToString();
                }
            }
        }

        public void timeStart()
        {
            if (availiable)
            {
                if (controlForm.vForm.InvokeRequired)
                {
                    controlForm.vForm.Invoke(new dd(timeStart));
                }
                else
                {
                    timeSec = controlForm.settings.getTime();
                    controlForm.vForm.timeLabel.Text = timeSec.ToString();
                    defaultT.Interval = 1000;
                    defaultT.Start();
                }
            }
        }

        public void timeStop()
        {
            defaultT.Stop();
        }

        public void buttonTime(object checkbox)
        {

        }

        public void buttonStop()
        {

        }
    }
}
