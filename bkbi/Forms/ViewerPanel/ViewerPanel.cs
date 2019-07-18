using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bkbi.Forms.ViewerPanel
{
    public partial class ViewerPanel : Form
    {

        System.Timers.Timer updater = new System.Timers.Timer();
        float PlayerAnimationFrame = 0.0f;

        public ViewerPanel()
        {
            InitializeComponent();
            updater.Elapsed += Updater_Elapsed;
            updater.Interval = 100;
            updater.Start();
        }

        private void Updater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if(!Core.Threads.ViewerPanelThread.IsAlive)
            {
                Close();
                return;
            }
            Invoke((MethodInvoker)
            (
                () =>
                {

                    //Timing
                    if(Core.Timing.TimeNow != -1)
                    {
                        TimeLabel.Text = Core.Timing.TimeNow.ToString();
                    }
                    else
                    {
                        TimeLabel.Text = "";
                    }
                    //Bir X
                    if (ViewerClass.current != null) switch (ViewerClass.current.Type)
                        {
                            case Core.Questions.TypeEnum.AutoEquation | Core.Questions.TypeEnum.UserEquation:
                                TypeLabel.Text = "Bir İşlem";
                                break;
                            case Core.Questions.TypeEnum.DictionaryWord | Core.Questions.TypeEnum.UserWord:
                                TypeLabel.Text = "Bir Kelime";
                                break;
                        }
                //chars
                if (ViewerClass.viewChars != null)
                    {
                        A.Text = ViewerClass.viewChars[0].ToString();
                        B.Text = ViewerClass.viewChars[1].ToString();
                        C.Text = ViewerClass.viewChars[2].ToString();
                        D.Text = ViewerClass.viewChars[3].ToString();
                        E.Text = ViewerClass.viewChars[4].ToString();
                        F.Text = ViewerClass.viewChars[5].ToString();
                        G.Text = ViewerClass.viewChars[6].ToString();
                        H.Text = ViewerClass.viewChars[7].ToString();
                    }

                    panel10.Visible = ViewerClass.views[0];
                    panel11.Visible = ViewerClass.views[1];
                    panel8.Visible = ViewerClass.views[2];
                    panel15.Visible = ViewerClass.views[3];
                    panel12.Visible = ViewerClass.views[4];
                    panel7.Visible = ViewerClass.views[5];
                    panel14.Visible = ViewerClass.views[6];
                    panel13.Visible = ViewerClass.views[7];
                    //points
                    PointLabel.Text = (Core.Timing.Running) ? Core.Questions.GetDeltaWorth((int)ViewerClass.currentPoints, (int)Core.Timing.TimeNow, (int)Core.Timing.StartLenght).ToString() : "";
                    panel9.Visible = ViewerClass.viewPoints;
                //Joker card
                jokerPanel.Visible = ViewerClass.viewJoker && ViewerClass.actualJoker;

                //Players
                if (Core.Player.All.Count <= 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Core.Player p = Core.Player.GetById(i + 1);

                            if (p != null)
                            {
                                if (i == 0)
                                {
                                    NameX.Text = p.Name;
                                    PointsX.Text = p.Points.ToString();
                                    PictureX.Image = p.PlayerIcon;
                                    PanelX.Visible = true;
                                }
                                if (i == 1)
                                {
                                    NameY.Text = p.Name;
                                    PointsY.Text = p.Points.ToString();
                                    PictureY.Image = p.PlayerIcon;
                                    PanelY.Visible = true;
                                }
                                if (i == 2)
                                {
                                    NameZ.Text = p.Name;
                                    PointsZ.Text = p.Points.ToString();
                                    PictureZ.Image = p.PlayerIcon;
                                    PanelZ.Visible = true;
                                }
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    PanelX.Visible = false;
                                }
                                if (i == 1)
                                {
                                    PanelY.Visible = false;
                                }
                                if (i == 2)
                                {
                                    PanelZ.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (PlayerAnimationFrame % 1 == 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Core.Player p;
                                if (PlayerAnimationFrame == 0)
                                {
                                    p = Core.Player.GetById(i + 1);
                                }
                                else
                                {
                                    p = Core.Player.GetById((i + 1) * ((int)PlayerAnimationFrame));
                                }

                                if (p != null)
                                {
                                    if (i == 0)
                                    {
                                        NameX.Text = p.Name;
                                        PointsX.Text = p.Points.ToString();
                                        PictureX.Image = p.PlayerIcon;
                                        PanelX.Visible = true;
                                    }
                                    if (i == 1)
                                    {
                                        NameY.Text = p.Name;
                                        PointsY.Text = p.Points.ToString();
                                        PictureY.Image = p.PlayerIcon;
                                        PanelY.Visible = true;
                                    }
                                    if (i == 2)
                                    {
                                        NameZ.Text = p.Name;
                                        PointsZ.Text = p.Points.ToString();
                                        PictureZ.Image = p.PlayerIcon;
                                        PanelZ.Visible = true;
                                    }
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        PanelX.Visible = false;
                                    }
                                    if (i == 1)
                                    {
                                        PanelY.Visible = false;
                                    }
                                    if (i == 2)
                                    {
                                        PanelZ.Visible = false;
                                    }
                                }
                            }
                        }
                        if (PlayerAnimationFrame > ((Core.Player.All.Count + (3 - (Core.Player.All.Count % 3))) / 3))
                        {
                            PlayerAnimationFrame = 0;
                        }
                        PlayerAnimationFrame = PlayerAnimationFrame + 0.1f;
                    }

                }
            ));
            
        }

        private void ViewerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            updater.Stop();
            updater.Dispose();
        }
    }
}
