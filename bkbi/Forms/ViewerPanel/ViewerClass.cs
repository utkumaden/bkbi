using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace bkbi.Forms.ViewerPanel
{
    static class ViewerClass
    {
        public static Core.Questions current;
        public static string[] viewChars = { "", "", "", "", "", "", "", "" };
        public static string[] questionchars;
        public static double currentPoints;
        public static bool viewJoker = true;
        public static bool viewPoints;
        public static bool actualJoker = false;
        public static bool[] views = new bool[8];
        public static bool colorizeTime = false;

        static Timer paneltimer = new Timer(1208);
        static Timer questionTimer = new Timer(50);

        public static System.Media.SoundPlayer ticker = new System.Media.SoundPlayer(Properties.Resources.tık);

        static ViewerClass()
        {
            paneltimer.Elapsed += Paneltimer_Elapsed;
            questionTimer.Elapsed += QuestionTimer_Elapsed;
        }

        static string[] alphachars =
        {
            "A",
            "B",
            "C",
            "Ç",
            "D",
            "E",
            "F",
            "G",
            "Ğ",
            "H",
            "I",
            "İ",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "Ö",
            "P",
            "R",
            "S",
            "Ş",
            "T",
            "U",
            "Ü",
            "V",
            "Y",
            "Z"
        };
        static int randomizedpanelindex = 0;
        static Random randomizer = new Random();
        private static void QuestionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(questionTimer.Interval == 250)
            {
                if(randomizedpanelindex!=8)viewChars[randomizedpanelindex] = questionchars[randomizedpanelindex];
                questionTimer.Interval = 50;
                if (randomizedpanelindex != 7) randomizedpanelindex++;
                else
                {
                    randomizedpanelindex = 0;
                    questionTimer.Stop();
                    if (Program.ControlPanel.autoStartCountdownTimerCheckBox.Checked) Core.Timing.StartTimer();
                }
            }
            else
            {
                switch (current.Type)
                {
                    case Core.Questions.TypeEnum.DictionaryWord:
                    case Core.Questions.TypeEnum.UserWord:
                        if(randomizedpanelindex != 8) viewChars[randomizedpanelindex] = alphachars[randomizer.Next(0, 29)];
                        ticker.Play();
                        break;
                    case Core.Questions.TypeEnum.AutoEquation:
                    case Core.Questions.TypeEnum.UserEquation:
                        if(randomizedpanelindex == 5)
                        {
                            viewChars[randomizedpanelindex] = (randomizer.Next(1, 20) * 5).ToString();
                            ticker.Play();
                        }
                        else if(randomizedpanelindex<5)
                        {
                            viewChars[randomizedpanelindex] = randomizer.Next(1, 11).ToString();
                            ticker.Play();
                        }
                        else
                        {
                            if(viewChars[randomizedpanelindex] != questionchars[randomizedpanelindex])
                            {
                                ticker.Play();
                            }
                            viewChars[randomizedpanelindex] = questionchars[randomizedpanelindex];
                        }
                        break;
                }

                switch (questionTimer.Interval)
                {
                    case 50:
                        questionTimer.Interval = 52;
                        break;
                    case 52:
                        questionTimer.Interval = 60;
                        break;
                    case 60:
                        questionTimer.Interval = 72;
                        break;
                    case 72:
                        questionTimer.Interval = 90;
                        break;
                    case 90:
                        questionTimer.Interval = 112;
                        break;
                    case 112:
                        questionTimer.Interval = 140;
                        break;
                    case 140:
                        questionTimer.Interval = 172;
                        break;
                    case 172:
                        questionTimer.Interval = 210;
                        break;
                    case 210:
                        questionTimer.Interval = 250;
                        break;
                }
            }            
        }

        internal static void setup(Core.Questions sent)
        {
            current = sent;
            questionchars = current.GetCompetitionArray();
            currentPoints = current.MaximumWorthInPoints;
            if(sent.GetType() == typeof(Core.DictionaryWord) || sent.GetType() == typeof(Core.UserWord))
            {
                actualJoker = true;
            }
            else
            {
                actualJoker = false;
            }
            viewChars = new string[] { "", "", "", "", "", "", "", "" };
            viewJoker = false;
            views = new bool[8];
            panel = 0;
            randomizedpanelindex = 0;
            paneltimer.Start();
        }

        static int panel = 0;
        private static void Paneltimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            switch (panel)
            {
                case 0:
                    viewPoints = true;
                    break;
                case 1:
                    viewJoker = true;
                break;
                case 2:
                    views[0] = true;
                    questionTimer.Start();
                    break;
                case 3:
                    views[1] = true;
                    break;
                case 4:
                    views[2] = true;
                    break;
                case 5:
                    views[3] = true;
                    break;
                case 6:
                    views[4] = true;
                    break;
                case 7:
                    views[5] = true;
                    break;
                case 8:
                    views[6] = true;
                    break;
                case 9:
                    views[7] = true;
                    paneltimer.Stop();
                    break;
            }
            ticker.Play();
            panel++;
        }
    }
}
