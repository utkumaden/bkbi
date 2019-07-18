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
        private Timer secondT = new Timer();
        private object iSender;
        int timeSec;
        int secondTimeSec = 10;
        bool alreadyDone;
        delegate void d(object sender, ElapsedEventArgs e);
        delegate void dd();
        public bool availiable = false;
        setting settings = controlForm.settings;
        iConsoleLibrary.iConsole gameConsole = controlForm.gameConsole;
        bool red = false;

        public timeKeeping()
        {
            defaultT.Elapsed += DefaultT_Elapsed;
            defaultcolorizer.Elapsed += Defaultcolorizer_Elapsed;
            buttoncolorizer.Elapsed += Buttoncolorizer_Elapsed;
            secondT.Elapsed += SecondT_Elapsed;
        }

        private void SecondT_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (controlForm.vForm.timeLabel.InvokeRequired) controlForm.vForm.Invoke(new d(SecondT_Elapsed), new object[] { null, null });
            else
            {
                if (!alreadyDone)
                {
                    defaultcolorizer.Interval = 500;
                    defaultcolorizer.Start();
                }
                if (int.Parse(controlForm.vForm.timeLabel.Text) <= 1)
                {
                    controlForm.vForm.timeLabel.Text = "0";
                    secondStop();
                    secondT.Enabled = false;
                    alreadyDone = false;
                    stopColor();
                }
                else
                {
                    controlForm.vForm.timeLabel.Text = (int.Parse(controlForm.vForm.timeLabel.Text) - 1).ToString();
                    settings.playBeep();
                }
            }
        }

        /// <summary>
        /// Colors the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttoncolorizer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Colorisez the time counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defaultcolorizer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (red)
            {
                controlForm.vForm.timeLabel.ForeColor = System.Drawing.Color.White;
                red = false;
            }
            else
            {
                controlForm.vForm.timeLabel.ForeColor = System.Drawing.Color.Red;
                red = true;
            }
        }

        /// <summary>
        /// The main timer for counting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultT_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (controlForm.vForm.timeLabel.InvokeRequired) controlForm.vForm.Invoke(new d(DefaultT_Elapsed), new object[] { null, null });
            else
            {
                if (int.Parse(controlForm.vForm.timeLabel.Text) <= 10 && !alreadyDone)
                {
                    defaultcolorizer.Interval = 500;
                    defaultcolorizer.Start();
                }
                if (int.Parse(controlForm.vForm.timeLabel.Text) <= 1)
                {
                    timeStop();
                    controlForm.vForm.timeLabel.Text = "0";                    
                    defaultT.Enabled = false;
                    alreadyDone = false;
                    stopColor();
                }
                else
                {
                    controlForm.vForm.timeLabel.Text = (int.Parse(controlForm.vForm.timeLabel.Text) - 1).ToString();
                }
                if(int.Parse(controlForm.vForm.timeLabel.Text) <= 10 && defaultT.Enabled)
                {
                    settings.playBeep();
                }
            }
        }

        void stopColor()
        {
            defaultcolorizer.Stop();
            controlForm.vForm.timeLabel.ForeColor = System.Drawing.Color.White;
            red = false;
        }

        /// <summary>
        /// Start the timers
        /// </summary>
        public void timeStart()
        {
            
            if (availiable)
            {
                if (controlForm.vForm.InvokeRequired)
                {
                    gameConsole.writeLine("[Time] Starting Countdown...");                    
                    controlForm.vForm.Invoke(new dd(timeStart));
                }
                else
                {                    
                    timeSec = controlForm.settings.getTime();
                    gameConsole.writeLightedLine("[Time] Coundown Lenght: " + timeSec.ToString());                    
                    controlForm.vForm.timeLabel.Text = timeSec.ToString();
                    defaultT.Interval = 1000;
                    defaultT.Start();
                }
            }
        }

        /// <summary>
        /// Stop the timer
        /// </summary>
        public void timeStop()
        {
            defaultT.Stop();
            settings.playTimeRanOutBuzzer();
            gameConsole.writeLine("[Time] Time ran out, and played the time ran out sound.", System.Drawing.Color.Green);
        }

        /// <summary>
        /// Stop the timer without playing the sound
        /// </summary>
        public void silentStop()
        {
            defaultT.Stop();
            gameConsole.writeLine("[Time] Countdown stopped silently, not playing time ran out sound.", System.Drawing.Color.Green);
        }

        public void secondTimerStart()
        {
            if (availiable && defaultT.Enabled)
            {
                if (controlForm.vForm.InvokeRequired)
                {
                    controlForm.vForm.Invoke(new dd(secondTimerStart));
                }
                else
                {
                    gameConsole.writeLine("[Time] Starting Second Countdown...");
                    silentStop();
                    gameConsole.writeLightedLine("[Time] Coundown Lenght: " + secondTimeSec.ToString());
                    controlForm.vForm.timeLabel.Text = secondTimeSec.ToString();
                    secondT.Interval = 1000;
                    secondT.Start();
                }
            }
        }

        public void secondStop()
        {
            secondT.Stop();
            secondT.Enabled = false;
            settings.playTimeRanOutBuzzer();
            gameConsole.writeLine("[Time] Second Countdown stopped, playing time ran out sound.");
        }

        public void secondSilentStop()
        {
            secondT.Stop();
            gameConsole.writeLine("[Time] Second Countdown stopped silently, not playing time ran out sound.");
        }

        /// <summary>
        /// Called when the button was pressed from an arduino
        /// </summary>
        /// <param name="checkbox"></param>
        public void buttonTime(object checkbox)
        {

        }

        /// <summary>
        /// Kill the button presses
        /// </summary>
        public void buttonStop()
        {

        }

        public void killall()
        {
            timeStop();
            secondStop();
        }

    }
}
