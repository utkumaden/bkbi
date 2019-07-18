using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Bir_Kelime_Bir_Islem
{
    public class Player
    {
        public string name = "Oyuncu";
        public int points = 0;
        public bool inGame = true;
        public Label nameLabel;        
        public Label mainLabel = new Label();
        public Label pmPointsLabel = new Label();
        public Label pmLabel = new Label();
        public Panel pPanel = new Panel();
        public System.Timers.Timer t = new System.Timers.Timer();
        public System.Timers.Timer u = new System.Timers.Timer();
        int pointstoAdd;
        int pointstoSub;
        delegate void iDelegate(object sender, System.Timers.ElapsedEventArgs e);
        SoundPlayer s = new SoundPlayer(Properties.Resources.addPointsSound);
        setting settings = controlForm.settings;
        iConsoleLibrary.iConsole gameConsole = controlForm.gameConsole;

        /// <summary>
        /// Called when the class is initiaized
        /// </summary>
        /// <param name="l">Points Label</param>
        /// <param name="m">How many points are being added/subtracted Label</param>
        /// <param name="n">+/- Label</param>
        /// <param name="p">Player Panel</param>
        /// <param name="name">Name Panel</param>
        public Player(Label l, Label m, Label n, Panel p, Label name)
        {
            t.Elapsed += addPointsAnimation;
            u.Elapsed += subPointsAnimation;
            mainLabel = l;
            pmPointsLabel = m;
            pmLabel = n;
            pPanel = p;
            nameLabel = name;  
        }

        /// <summary>
        /// Set the name of the Player
        /// </summary>
        /// <param name="na"></param>
        public void setName(string na)
        {
            gameConsole.writeLine("[Player] " + name + "'s name changed to " + na + ".");
            name = na;
            update();
        }      

        /// <summary>
        /// The animation for adding points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void addPointsAnimation(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (controlForm.vForm.InvokeRequired)
            {
                controlForm.vForm.Invoke(new iDelegate(addPointsAnimation), new object[] { null, null });
            }
            else
            {
                if (pointstoAdd <= 0) { t.Stop(); pmPointsLabel.Visible = false; }
                else
                {
                    mainLabel.Text = (Int32.Parse(mainLabel.Text) + 1).ToString();
                    pmPointsLabel.Text = (Int32.Parse(pmPointsLabel.Text) - 1).ToString();
                    pointstoAdd--;
                    settings.playAdd();
                }
            }
        }

        /// <summary>
        /// Add points to the player
        /// </summary>
        /// <param name="i"></param>
        public void addPoints(int i)
        {
            pointstoAdd = i;
            pmLabel.Text = "+";
            pmPointsLabel.Text = i.ToString();
            pmPointsLabel.Visible = true;
            gameConsole.writeLine("[Player] Adding " + pointstoAdd.ToString() + " points to " + name + ".");
            t.Interval = 100;
            t.Start();
            points = points + i;          
        }

        /// <summary>
        /// Subtract points from the player
        /// </summary>
        /// <param name="i"></param>
        public void subPoints(int i)
        {
            pointstoSub = i;
            pmLabel.Text = "-";
            pmPointsLabel.Text = i.ToString();
            pmPointsLabel.Visible = true;
            gameConsole.writeLine("[Player] Subtracting " + i.ToString() + " points from " + name + ".");
            u.Interval = 100;
            u.Start();
            points = points - i;
        }

        /// <summary>
        /// The animation for subtracting points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subPointsAnimation(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (controlForm.vForm.InvokeRequired)
            {
                controlForm.vForm.Invoke(new iDelegate(subPointsAnimation), new object[] { null, null });
            }
            else
            {
                if (pointstoSub <= 0) { u.Stop(); pmPointsLabel.Visible = false; update(); }
                else
                {
                    mainLabel.Text = (Int32.Parse(mainLabel.Text) - 1).ToString();
                    pmPointsLabel.Text = (Int32.Parse(pmPointsLabel.Text) - 1).ToString();
                    pointstoSub--;
                }
            }
        }

        /// <summary>
        /// Update the viewer window
        /// </summary>
        public void update()
        {
            nameLabel.Text = name;
            mainLabel.Text = points.ToString();
            if (inGame) { pPanel.Visible = true; }
            else { pPanel.Visible = false; }
        }

        /// <summary>
        /// Update the Paramaters if needed
        /// </summary>
        /// <param name="l">Points Label</param>
        /// <param name="m">How many points are being added/subtracted Label</param>
        /// <param name="n">+/- Label</param>
        /// <param name="p">Player Panel</param>
        /// <param name="name">Name Panel</param>
        public void updateParams(Label l, Label m, Label n, Panel p, Label name)
        {
            mainLabel = l;
            pmPointsLabel = m;
            pmLabel = n;
            pPanel = p;
            nameLabel = name;
            update();
        }

        /// <summary>
        /// Set points if the player
        /// </summary>
        /// <param name="i"></param>
        public void setPoints(int i)
        {
            points = i;
            gameConsole.writeLine("[Player] Changed " + name + "'s points to" + i.ToString());
            update();
        }

    }
}
