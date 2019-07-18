using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using timer = System.Timers;
using System.Threading;

using System.Media;
using System.IO;

namespace bkbi.Core
{
    public static class Timing
    {
        public static int StartLenght = 60;
        public static int AlarmLenght = 10;
        public static int TimeNow = -1;

        public static timer::Timer ActualTimer = new timer::Timer();
        public static timer::Timer AlarmTimer = new timer::Timer(1000);

        static SoundPlayer Doorbell = new SoundPlayer(Properties.Resources.Doorbell);

        public static bool Running;

        public static void init()
        {
            ActualTimer.Interval = 1000;
            ActualTimer.Elapsed += ActualTimer_Elapsed;
            AlarmTimer.Elapsed += AlarmTimer_Elapsed;
        }

        private static void AlarmTimer_Elapsed(object sender, timer.ElapsedEventArgs e)
        {
            switch (TimeNow)
            {
                case 9:
                case 5:
                case 2:
                case 3:
                case 1:
                    Forms.ViewerPanel.ViewerClass.ticker.Play();                    
                    break;
            }
            Forms.ViewerPanel.ViewerClass.colorizeTime = !Forms.ViewerPanel.ViewerClass.colorizeTime;
        }

        private static void ActualTimer_Elapsed(object sender, timer::ElapsedEventArgs e)
        {
            if (TimeNow < 0) {  StopTimer(); return; }
            if (TimeNow < AlarmLenght) AlarmTimer.Start();
            TimeNow--;
            if (TimeNow == 0) Doorbell.Play();
        }

        public static void StartTimer()
        {
            TimeNow = StartLenght;
            Running = true;
            ActualTimer.Enabled = true;
        }

        public  static void StopTimer()
        {
            ActualTimer.Enabled = false;
            AlarmTimer.Enabled = false;
            Running = false;
            Forms.ViewerPanel.ViewerClass.colorizeTime = false;
            TimeNow = -1;
        }

        public static void Pause(bool pause = true)
        {
            ActualTimer.Enabled = !pause;
        }
    }
}
