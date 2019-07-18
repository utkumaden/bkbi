using Bir_Kelime_Bir_Islem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iConsoleLibrary;
using System.IO;
using System.Threading;
using System.Timers;
using System.Media;
using System.Xml;

namespace Bir_Kelime_Bir_Islem
{
    public partial class controlForm : Form
    {
        static string cmdLocation = Environment.GetEnvironmentVariable("appdata") + @"\Bir Kelime Bir İşlem\iConsole";
        public delegate void d(object sender, ElapsedEventArgs e);
        public static iConsole gameConsole = new iConsole(cmdLocation);
        System.Timers.Timer animeClock = new System.Timers.Timer();
        public static setting settings = new setting();
        public static viewerForm vForm = new viewerForm();
        public static Player P1 = new Player(vForm.P1Points, vForm.P1pm, vForm.P1plus, vForm.panel1, vForm.P1name);
        public static Player P2 = new Player(vForm.P2Points, vForm.P2pm, vForm.P2plus, vForm.panel2, vForm.P2name);
        public static Player P3 = new Player(vForm.P3Points, vForm.P3pm, vForm.P3plus, vForm.panel3, vForm.P3name);
        timeKeeping times = new timeKeeping();
        prePreparedGameHandler prePreparedGame = new prePreparedGameHandler();
        Forms.Main.console consoleForm = new Forms.Main.console();
        int animationplace = -1;
        int animationTick = 1000;
        bool animeWithJoker = false;
        string gamePath;
        XmlDocument game = new XmlDocument();
        XmlDocument config = new XmlDocument();
        bool gameloaded = false;
        uint gameProgress = 0;
        Thread timeThread;



        //TODO: Cleanify the Program...

        public static string ShortenPath(string path, int maxLength)
        {
            string ellipsisChars = "...";
            char dirSeperatorChar = Path.DirectorySeparatorChar;
            string directorySeperator = dirSeperatorChar.ToString();

            //simple guards
            if (path.Length <= maxLength)
            {
                return path;
            }
            int ellipsisLength = ellipsisChars.Length;
            if (maxLength <= ellipsisLength)
            {
                return ellipsisChars;
            }


            //alternate between taking a section from the start (firstPart) or the path and the end (lastPart)
            bool isFirstPartsTurn = true; //drive letter has first priority, so start with that and see what else there is room for

            //vars for accumulating the first and last parts of the final shortened path
            string firstPart = "";
            string lastPart = "";
            //keeping track of how many first/last parts have already been added to the shortened path
            int firstPartsUsed = 0;
            int lastPartsUsed = 0;

            string[] pathParts = path.Split(dirSeperatorChar);
            for (int i = 0; i < pathParts.Length; i++)
            {
                if (isFirstPartsTurn)
                {
                    string partToAdd = pathParts[firstPartsUsed] + directorySeperator;
                    if ((firstPart.Length + lastPart.Length + partToAdd.Length + ellipsisLength) > maxLength)
                    {
                        break;
                    }
                    firstPart = firstPart + partToAdd;
                    if (partToAdd == directorySeperator)
                    {
                        //this is most likely the first part of and UNC or relative path 
                        //do not switch to lastpart, as these are not "true" directory seperators
                        //otherwise "\\myserver\theshare\outproject\www_project\file.txt" becomes "\\...\www_project\file.txt" instead of the intended "\\myserver\...\file.txt")
                    }
                    else
                    {
                        isFirstPartsTurn = false;
                    }
                    firstPartsUsed++;
                }
                else
                {
                    int index = pathParts.Length - lastPartsUsed - 1; //-1 because of length vs. zero-based indexing
                    string partToAdd = directorySeperator + pathParts[index];
                    if ((firstPart.Length + lastPart.Length + partToAdd.Length + ellipsisLength) > maxLength)
                    {
                        break;
                    }
                    lastPart = partToAdd + lastPart;
                    if (partToAdd == directorySeperator)
                    {
                        //this is most likely the last part of a relative path (e.g. "\websites\myproject\www_myproj\App_Data\")
                        //do not proceed to processing firstPart yet
                    }
                    else
                    {
                        isFirstPartsTurn = true;
                    }
                    lastPartsUsed++;
                }
            }

            if (lastPart == "")
            {
                //the filename (and root path) in itself was longer than maxLength, shorten it
                lastPart = pathParts[pathParts.Length - 1];//"pathParts[pathParts.Length -1]" is the equivalent of "Path.GetFileName(pathToShorten)"
                lastPart = lastPart.Substring(lastPart.Length + ellipsisLength + firstPart.Length - maxLength, maxLength - ellipsisLength - firstPart.Length);
            }

            return firstPart + ellipsisChars + lastPart;
        }

        public controlForm()
        {
            consoleForm.Show();
            consoleForm.Hide();
            InitializeComponent();
            gameConsole.initiate(consoleForm.outbox, consoleForm.inbox, consoleForm.sendCmd, consoleForm);
            gameConsole.illegalCommandMessage = "Yanlış Komut, Tekrar Deneyin...";
            animeClock.Elapsed += AnimeClock_Elapsed;
            hideAll();
            timeThread = new Thread(new ThreadStart(timeHasToStart));
            gameConsole.writeLine("Program Başarıyla Başladı!", Color.LimeGreen);
            gameConsole.writeLine("Bu konsoldaki tüm komutlar ingilizcedir. Yardım için 'help' yazın.");
            startTimewithoutAI_Click(null, null);
            startTimewithoutAI.Text = "Arduinosuz Zaman Özelliği Açık.";
            try
            {
                if (Environment.GetCommandLineArgs()[1] == "-debug") gameConsole.writeLightedLine("-debug parameter, skipping exception reporter, allowing VS debugger to handle exceptions.");
            }
            catch { }
            if(settings.getAutoGamePath()!=string.Empty && settings.getUseAutoGames())
            {
                openGame.FileName = settings.getAutoGamePath();
                try
                {
                    prePreparedGame.loadGame(openGame.FileName);
                }
                catch
                {
                    MessageBox.Show("Yüklenen oyunda bir sorun  var, muhtemelen dosya yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    gameConsole.writeLine("[PPG] Unknown error accoured while loading game, most likely there's a problem with the file");
                }

                outOf.Text = prePreparedGame.max.ToString();
                prePreparedProgress.Maximum = (int)prePreparedGame.max;
                prePreparedProgress.Value = 1;

                showGame.Enabled = true;
                preparedSetButton.Enabled = true;
                previousItem.Enabled = true;
                nextItem.Enabled = true;
                stopPrePrepared.Enabled = true;
                whereAmIbox.Enabled = true;
                prePreparedGame.setPlace(1);
                stopPrePrepared.Enabled = true;

                prePreparedSection(true);
                gameConsole.writeLine("[PPG] Game succesfully loaded! From:" + ShortenPath(openGame.FileName, 50));
            }

        }

        public void iLoader(string path)
        {
            openGame.FileName = path;
            try
            {
                prePreparedGame.loadGame(openGame.FileName);
            }
            catch
            {
                MessageBox.Show("Yüklenen oyunda bir sorun  var, muhtemelen dosya yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                gameConsole.writeLine("[PPG] Unknown error accoured while loading game, most likely there's a problem with the file");
            }

            outOf.Text = prePreparedGame.max.ToString();
            prePreparedProgress.Maximum = (int)prePreparedGame.max;
            prePreparedProgress.Value = 1;

            showGame.Enabled = true;
            preparedSetButton.Enabled = true;
            previousItem.Enabled = true;
            nextItem.Enabled = true;
            stopPrePrepared.Enabled = true;
            whereAmIbox.Enabled = true;
            prePreparedGame.setPlace(1);
            stopPrePrepared.Enabled = true;

            prePreparedSection(true);
            gameConsole.writeLine("[PPG] Game succesfully loaded! From:" + ShortenPath(openGame.FileName, 50));
        }

        private void AnimeClock_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (vForm.InvokeRequired)
            {
                vForm.Invoke(new d(AnimeClock_Elapsed), new object[] { null, null });
            }
            else
            {
                if (animationplace > 7)
                {
                    if (animeWithJoker)
                    {
                        if (animationplace > 8)
                        {
                            animationplace = -1;
                            animeClock.Stop();
                            gameConsole.writeLine("[Animation] Joker boolean was present, Animation done and stopping neccesary timers.", Color.Green);
                            return;
                        }
                    }
                    else
                    {
                        animationplace = -1;
                        animeClock.Stop();
                        gameConsole.writeLine("[Animation] Animation done, stopping neccesary timers.", Color.Green);
                        return;
                    }
                }
                settings.playAnime();
                if (animationplace == -1) vForm.GameLabel.Visible = true;
                if (animationplace == 0) vForm.PanelA.Visible = true;
                if (animationplace == 1) vForm.PanelB.Visible = true;    
                if (animationplace == 2) vForm.PanelC.Visible = true;    
                if (animationplace == 3) vForm.PanelD.Visible = true;
                if (animationplace == 4) vForm.PanelE.Visible = true;
                if (animationplace == 5) vForm.PanelF.Visible = true;
                if (animationplace == 6) vForm.PanelG.Visible = true;
                if (animationplace == 7) vForm.PanelH.Visible = true;
                if (animeWithJoker) if (animationplace == 8) vForm.jokerPanel.Visible = true;
                animationplace++;
                gameConsole.writeLine("[Animation] Tick Successful.");                
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.Show();
        }

        #region Players

        #region Main Buttons

        /// <summary>
        /// Open the P1 options menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P1Button_Click(object sender, EventArgs e)
        {
            P1ContextMenu.Show(Cursor.Position);
        }

        /// <summary>
        /// Open the P2 options menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P2Button_Click(object sender, EventArgs e)
        {
            P2ContextMenu.Show(Cursor.Position);
        }

        /// <summary>
        /// Open the P3 options menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3Button_Click(object sender, EventArgs e)
        {
            P3ContextMenu.Show(Cursor.Position);
        }

        #endregion

        #region Add Points

        /// <summary>
        /// Show add points to Player 1 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P1AddPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AddPoints.P1Add().Show();
        }

        /// <summary>
        /// Show add points to Player 2 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P2AddPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AddPoints.P2Add().Show();
        }

        /// <summary>
        /// Show add points to Player 3 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3AddPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AddPoints.P3Add().Show();
        }

        #endregion

        #region Sub Points

        /// <summary>
        /// Show subtract points from Player 1 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P1SubPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.SubPoints.P1Sub().Show();
        }

        /// <summary>
        /// Show subtract points from Player 1 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P2SubPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.SubPoints.P2Sub().Show();
        }

        /// <summary>
        /// Show subtract points from Player 1 dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3SubPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.SubPoints.P3Sub().Show();
        }

        #endregion

        #region Names

        private void P1NameChange(object sender, EventArgs e)
        {
            P1.setName(P1nameToolStripTextBox.Text);
        }

        private void P2NameChange(object sender, EventArgs e)
        {
            P2.setName(P2nameToolStripTextBox.Text);
        }

        private void P3NameChange(object sender, EventArgs e)
        {
            P3.setName(P3nameToolStripTextBox.Text);
        }

        #endregion

        #endregion

        /// <summary>
        /// Scrambles and sends the word to the viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendWordButton_Click(object sender, EventArgs e)
        {
           
            vForm.GameLabel.Text = "Bir Kelime";
            vForm.H.Font = new Font("Verdana", 48, FontStyle.Regular);
            vForm.F.Font = new Font("Verdana", 48, FontStyle.Regular);
            hideAll();
            if (sendWordTextBox.Text.Length != 8)
              {
                  MessageBox.Show("Kelime 8 Harfli Olmak Zorunda!", "Kelime Geçersiz", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  gameConsole.writeErrorLine("[Word] Word Invalid, shorter than 8 characters");
                  return;
              }

                  string[] input = { "", "", "", "", "", "", "", "", "" };
                  bool[] numUsed = { false, false, false, false, false, false, false, false };
                  string[] output = { "", "", "", "", "", "", "", "", "" };
                  int place = 0;
                  string checkstring = "";
                  string stringtoCheck = "";
                  Random r = new Random();
                  int toMix;
                  int tooCrazyToHandle = 150;
                  int tries = 0;
                  gameConsole.writeLine("[Word] Initialized");
                  while (place < 8)
                  {
                      input[place] = sendWordTextBox.Text.Substring(place, 1).ToUpper();
                      place++;
                  }

              notGoodenough:
                  place = 0;
                  numUsed[0] = false;
                  numUsed[1] = false;
                  numUsed[2] = false;
                  numUsed[3] = false;
                  numUsed[4] = false;
                  numUsed[5] = false;
                  numUsed[6] = false;
                  numUsed[7] = false;
                  tries++;
                  if (tries > tooCrazyToHandle)
                  {
                      gameConsole.writeErrorLine("[Word] Scramble seems impossible, quitting");
                      MessageBox.Show("Kelime Karıştırılamadı, kelime çok fazla benzer karakter bulunduruyor ya da karıştırması imkansız.", "Kelime Karıştırılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }
                  gameConsole.writeLine("[Word] Scrambling...");
                  while (!(numUsed[0] && numUsed[1] && numUsed[2] && numUsed[3] && numUsed[4] && numUsed[5] && numUsed[6] && numUsed[7]))
                  {

                  to:
                      toMix = r.Next(0, 8);
                      if (numUsed[toMix]) goto to;
                      output[toMix] = input[place];
                      numUsed[toMix] = true;
                      place++;
                  }
                  place = 0;

                  gameConsole.writeLine("[Word] Testing scramble...");
                  while (place < 7)
                  {
                      checkstring = input[0] + input[1];
                      for (int i = 0; i < 7; i++)
                      {
                         stringtoCheck = output[i] + output[i + 1];
                         if (stringtoCheck == checkstring)
                         {
                             gameConsole.writeLine("[Word] Scramble unsuccesful (Scramble retuned the word itself), rescrambling... ");
                             goto notGoodenough;
                         }
                      }

                  checkstring = input[1] + input[2];
                  for (int i = 0; i < 7; i++)
                  {
                      stringtoCheck = output[i] + output[i + 1];
                      if (stringtoCheck == checkstring)
                      {
                          gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                          goto notGoodenough;
                      }
                  }

                        checkstring = input[2] + input[3];
                        for (int i = 0; i < 7; i++)
                        {
                            stringtoCheck = output[i] + output[i + 1];
                            if (stringtoCheck == checkstring)
                            {
                                gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                                goto notGoodenough;
                            }
                        }

                        checkstring = input[3] + input[4];
                        for (int i = 0; i < 7; i++)
                        {
                            stringtoCheck = output[i] + output[i + 1];
                            if (stringtoCheck == checkstring)
                            {
                                gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                                goto notGoodenough;
                            }
                        }

                        checkstring = input[4] + input[5];
                        for (int i = 0; i < 7; i++)
                        {
                            stringtoCheck = output[i] + output[i + 1];
                            if (stringtoCheck == checkstring)
                            {
                                gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                                goto notGoodenough;
                            }
                        }

                        checkstring = input[5] + input[6];
                        for (int i = 0; i < 7; i++)
                        {
                            stringtoCheck = output[i] + output[i + 1];
                            if (stringtoCheck == checkstring)
                            {
                                gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                                goto notGoodenough;
                            }
                        }

                        checkstring = input[6] + input[7];
                        for (int i = 0; i < 7; i++)
                        {
                            stringtoCheck = output[i] + output[i + 1];
                            if (stringtoCheck == checkstring)
                            {
                                gameConsole.writeErrorLine("[Word] Scramble unsuccesful (Scramble contained a sequence from the word), rescrambling... ");
                                goto notGoodenough;
                            }
                        }
                        place++;
             }
            vForm.A.Text = output[0];
            vForm.B.Text = output[1];
            vForm.C.Text = output[2];
            vForm.D.Text = output[3];
            vForm.E.Text = output[4];
            vForm.F.Text = output[5];
            vForm.G.Text = output[6];
            vForm.H.Text = output[7];
            gameConsole.writeLine("[Word] Scramble Succesful!", Color.Green);
            animate(true);
        }                    

        /// <summary>
        /// Happens when the app window is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            animeClock.Stop();
            animeClock.Dispose();
            gameConsole.writeLine("Closing... All Items Disposed. Goodbye!");
        }

        
        /// <summary>
        /// Change the default button to Sen Word button when the word entry box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Click(object sender, EventArgs e)
        {
            AcceptButton = sendWordButton;
        }

        /// <summary>
        /// Set the default button of the control form to none
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noAcceptButton(object sender, EventArgs e)
        {
            AcceptButton = null;
        }       

        /// <summary>
        /// Close the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Show Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yardımToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //TODO: Implement help
        }

        /// <summary>
        /// Sends a random equaition to the viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendEquationButton_Click(object sender, EventArgs e)
        {
            gameConsole.writeLine("[Equation] Randomizing...");
            vForm.GameLabel.Text = "Bir İşlem";
            vForm.G.Text = "=";
            vForm.H.Font = new Font("Verdana", 24, FontStyle.Regular);
            vForm.F.Font = new Font("Verdana", 24, FontStyle.Regular);
            hideAll();
            Random r = new Random();
            int[] nums = { 0, 0, 0, 0, 0, 0, 0 };
            int outnum;
            int[] bigNums = { 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95 };
            outnum = r.Next(100, 999);
            nums[0] = r.Next(1, 10);
            nums[1] = r.Next(1, 10);
            nums[2] = r.Next(1, 10);
            nums[3] = r.Next(1, 10);
            nums[4] = r.Next(1, 10);
            nums[5] = bigNums[r.Next(0, 17)];

            vForm.A.Text = nums[0].ToString();
            vForm.B.Text = nums[1].ToString();
            vForm.C.Text = nums[2].ToString();
            vForm.D.Text = nums[3].ToString();
            vForm.E.Text = nums[4].ToString();
            vForm.F.Text = nums[5].ToString();
            vForm.H.Text = outnum.ToString();
            gameConsole.writeLine("[Equation] Randomize Succesful!", Color.Green);
            animate(false);

        }

        /// <summary>
        /// Change if the P2 is still in game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P1ingameToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ingameToolStripMenuItem.Checked) P1.inGame = true;
            else P1.inGame = false;

            P1.update();
                                    
        }

        /// <summary>
        /// Change if the P2 is still in game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P2ingame_CheckedChanged(object sender, EventArgs e)
        {

            if (P2ingame.Checked) P2.inGame = true;
            else P2.inGame = false;

            P2.update();
        }

        /// <summary>
        /// Change if the P3 is still in game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3ingameToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {

            if (P3ingameToolStripMenuItem.Checked) P3.inGame = true;
            else P3.inGame = false;

            P3.update();
        }

        private void depricated()
        {
            gameConsole.writeLine("SAYI: ...");
        ifailedyou:

            int[] regularnumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] bignumbers = { 10, 15, 20, 25, 30, 35, 40, 55, 60, 65, 70, 75, 80, 85, 90, 95 };
            string[] typeOfOperation = { "none", "none", "none", "none", "none" };
            int outNumber = 0;
            int[] outNums = { 0, 0, 0, 0, 0, 0 };
            Random r = new Random();
            int z = 0;
            int tries = 0;

            gameConsole.writeLine("SAYI: Karıştırılıyor...");
            while (outNums[0] == 0 || outNums[1] == 0 || outNums[2] == 0 || outNums[3] == 0 || outNums[4] == 0)
            {
                outNums[z] = regularnumbers[r.Next(0, 9)];
                z++;
            }

            outNums[5] = bignumbers[r.Next(0, 16)];

            gameConsole.writeLine("SAYI: Karıştırıldı.");

            z = 0;
            int opToHandle;
        toreturn:
            tries++;
            if (tries > 50) { gameConsole.writeErrorLine("SAYI: Bu sayı dizisi ile yapılamıyor, sayı dizesi yeniden belirleniyor..."); goto ifailedyou; }
            typeOfOperation[0] = "none";
            typeOfOperation[1] = "none";
            typeOfOperation[2] = "none";
            typeOfOperation[3] = "none";
            typeOfOperation[4] = "none";

            gameConsole.writeLine("SAYI: İşlemler Belirleniyor...");

            while (z < 5)
            {
                opToHandle = r.Next(1, 5);
                if (opToHandle == 1)
                {
                    typeOfOperation[z] = "add";
                }
                if (opToHandle == 2)
                {
                    typeOfOperation[z] = "sub";
                }
                if (opToHandle == 3)
                {
                    typeOfOperation[z] = "mlt";
                }
                if (opToHandle == 4)
                {
                    typeOfOperation[z] = "div";
                }
                z++;

            }

            gameConsole.writeLine("SAYI: İşlemler belirlendi.");

            bool[] used = { false, false, false, false, false, false };
            int a;
            int op = 0;
            z = 0;

            gameConsole.writeLine("SAYI: İşlemler yapılıyor...");
            

            while (!used[0] || !used[1] || !used[2] || !used[3] || !used[4] || !used[5])
            {
            anotherLabel:
                z = r.Next(0, 6);
                if (used[z]) goto anotherLabel;
                else used[z] = true;
                moarlabels:

                a = outNums[z];

                if (typeOfOperation[op] == "add") { outNumber = outNumber + a; }
                if (typeOfOperation[op] == "sub") { outNumber = outNumber - a; }
                if (typeOfOperation[op] == "mlt") { outNumber = outNumber * a; }
                if (typeOfOperation[op] == "div") { outNumber = outNumber / a; }
            }

            gameConsole.writeLine("SAYI: İşlemler Yapıldı, Kontrol Ediliyor...");

            if (outNumber <= 0 || outNumber < 100 || outNumber > 999) { gameConsole.writeErrorLine("SAYI: Bulunan sayı çok küçük veya negatif. Yeniden işlem hazırlanıyor."); goto toreturn; }
            else
            {
                vForm.A.Text = outNums[0].ToString();
                vForm.B.Text = outNums[1].ToString();
                vForm.C.Text = outNums[2].ToString();
                vForm.D.Text = outNums[3].ToString();
                vForm.E.Text = outNums[4].ToString();
                vForm.F.Text = outNums[5].ToString();
                vForm.H.Text = outNumber.ToString();
            }
            gameConsole.writeLine("SAYI: Tamamlandı!", Color.DarkGreen);
        }

        /// <summary>
        /// Starts the time as soon as animation ends
        /// </summary>
        private void timeHasToStart()
        {
            while (true)
            {
                if (!animeClock.Enabled) { times.timeStart(); break; }
                Thread.Sleep(100);
            }
        }
        
        /// <summary>
        /// Animate the viewer window
        /// </summary>
        /// <param name="b">Should the Joker be Animated</param>
        private void animate(bool b)
        {
            gameConsole.writeLine("[Animation] Animating!");
            hideAll();
            animeWithJoker = b;
            animeClock.Interval = animationTick;
            animeClock.Stop();
            timeThread.Abort();
            timeThread = new Thread(new ThreadStart(timeHasToStart));
            animeClock.Start();
            gameConsole.writeLine("[Time] Forcing countdown to start as soon as animation stops.");
            timeThread.Start();
        }

        /// <summary>
        /// Hide All the boxes etc. in the viewer window
        /// </summary>
        public void hideAll()
        {
            vForm.GameLabel.Visible = false;
            vForm.PanelA.Visible = false;
            vForm.PanelB.Visible = false;
            vForm.PanelC.Visible = false;
            vForm.PanelD.Visible = false;
            vForm.PanelE.Visible = false;
            vForm.PanelF.Visible = false;
            vForm.PanelG.Visible = false;
            vForm.PanelH.Visible = false;
            vForm.jokerPanel.Visible = false;
        }

        /// <summary>
        /// Happens when you press the prePrepared Options Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prePreparedOptionsButton_Click(object sender, EventArgs e)
        {
            int[] i = { 0, 0 };
            i[0] = MousePosition.X;
            i[1] = MousePosition.Y;
            prePreparedMenustrip.Show(new Point(i[0], i[1]));
        }

        private void makeGame_Click(object sender, EventArgs e)
        {
            new prePreparedPreparer().Show();
        }

        /// <summary>
        /// [depricated]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void old_loadGame_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Shows the settings Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.Main.settingsGUI().Show();
        }

        /// <summary>
        /// Enable time without arduino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTimewithoutAI_Click(object sender, EventArgs e)
        {
            gameConsole.writeLine("[Time] Timing on without Arduino, no button support.");
            times.availiable = true;
            stopTime.Enabled = true;
        }

        /// <summary>
        /// Open the viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openViewerWindow_Click(object sender, EventArgs e)
        {
            enabler();
            new viewerWindowPlacer().Show();
            gameConsole.writeLine("Viewer Window due to be shown");
        }

        /// <summary>
        /// Enables most of the controls on the window
        /// </summary>
        public void enabler()
        {
            sendEquationGroupBox.Enabled = true;
            sendWordGroupBox.Enabled = true;
            P1button.Enabled = true;
            P2button.Enabled = true;
            P3button.Enabled = true;
            prePreparedOptionsButton.Enabled = true;
            startTimewithoutAI.Enabled = true;
        }

        #region PrePrepared Games

        #region Create
        #endregion

        #region Play
        /// <summary>
        /// Does things when the the Numeric Up Down box value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void whereAmIbox_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as NumericUpDown).Value == 0)
            {
                (sender as NumericUpDown).Value = 1;
                prePreparedGame.setPlace(1);
                prePreparedProgress.Value = 1;
            }
            else if ((sender as NumericUpDown).Value > prePreparedProgress.Maximum)
            {
                prePreparedGame.setPlace((uint)prePreparedProgress.Maximum);
                (sender as NumericUpDown).Value = prePreparedProgress.Maximum;
                prePreparedProgress.Value = prePreparedProgress.Maximum;
            }
            else
            {
                prePreparedGame.setPlace((uint)(sender as NumericUpDown).Value);
                prePreparedProgress.Value = (int)prePreparedGame.place;
            }
        }

        /// <summary>
        /// Stops the time if it is running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopTime_Click(object sender, EventArgs e)
        {
            times.killall();
        }

        /// <summary>
        /// Load the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGame_Click(object sender, EventArgs e)
        {
            DialogResult r = openGame.ShowDialog();
            if (r == DialogResult.Cancel) return;

            try
            {
                prePreparedGame.loadGame(openGame.FileName);
            }
            catch
            {
                MessageBox.Show("Yüklenen oyunda bir sorun  var, muhtemelen dosya yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                gameConsole.writeLine("[PPG] Unknown error accoured while loading game, most likely there's a problem with the file");
            }

            outOf.Text = prePreparedGame.max.ToString();
            prePreparedProgress.Maximum = (int)prePreparedGame.max;
            prePreparedProgress.Value = 1;

            showGame.Enabled = true;
            preparedSetButton.Enabled = true;
            previousItem.Enabled = true;
            nextItem.Enabled = true;
            stopPrePrepared.Enabled = true;
            whereAmIbox.Enabled = true;
            prePreparedGame.setPlace(1);
            stopPrePrepared.Enabled = true;

            prePreparedSection(true);
            gameConsole.writeLine("[PPG] Game succesfully loaded! From:" + ShortenPath(openGame.FileName, 50));
        }

        /// <summary>
        /// Send the Item to the viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showGame_Click(object sender, EventArgs e)
        {
            if (prePreparedGame.loaded)
            {
                Form s = new Forms.List.lister(openGame.FileName, (int) prePreparedGame.place);
                s.Show();
            }
            else
            {
                Form s = new Forms.List.lister(openGame.FileName);
                s.Show();
            }
        }

        /// <summary>
        /// Stops the prePreparedGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopPrePrepared_Click(object sender, EventArgs e)
        {
            prePreparedGame.unload();
            stopPrePrepared.Enabled = false;
            prePreparedSection(false);
            gameConsole.writeLine("[PPG] Game unloaded.");
        }

        /// <summary>
        /// Load a prePreparedGame Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preparedSetButton_Click(object sender, EventArgs e)
        {
            if (prePreparedGame.selectedItem.Type.Equals(gameType.Word))
            {
                try
                {
                    gameConsole.writeLine("[PPG] Tricking \"Word\" to scramble item from the file...");
                    sendWordTextBox.Text = prePreparedGame.selectedItem.Value as string;
                    sendWordButton_Click(null, null);
                    sendWordTextBox.Text = "";
                }
                catch
                {
                    MessageBox.Show("Hazır oyunda hata var, bu öge bozuk. Sıradakine geçin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    gameConsole.writeLine("[PPG] Unknown error accoured, game item might be broken in the loaded game");
                }
            }

            else
            {
                try
                {
                    gameConsole.writeLine("[PPG] Sending Equation To Screen...");
                    vForm.GameLabel.Text = "Bir İşlem";
                    vForm.G.Text = "=";
                    vForm.H.Font = new Font("Verdana", 24, FontStyle.Regular);
                    vForm.F.Font = new Font("Verdana", 24, FontStyle.Regular);
                    hideAll();
                    string[] write = prePreparedGame.selectedItem.Value as string[];
                    vForm.A.Text = write[1];
                    vForm.B.Text = write[2];
                    vForm.C.Text = write[3];
                    vForm.D.Text = write[4];
                    vForm.E.Text = write[5];
                    vForm.F.Text = write[6];
                    vForm.H.Text = write[0];
                    animate(false);
                }
                catch
                {
                    MessageBox.Show("Hazır oyunda hata var, bu öge bozuk. Sıradakine geçin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    gameConsole.writeLine("[PPG] Unknown error accoured, game item might be broken in the loaded game");
                }
            }

        }

        /// <summary>
        /// Change the prePreparedItem to the previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousItem_Click(object sender, EventArgs e)
        {
            if (!(prePreparedGame.place < 1))
            {
                prePreparedGame.previous();
                prePreparedProgress.Value = (int)prePreparedGame.place;
                whereAmIbox.Value = prePreparedGame.place;
            }
        }

        /// <summary>
        /// Change the prePreparedItem to the next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextItem_Click(object sender, EventArgs e)
        {
            if (prePreparedGame.place != prePreparedProgress.Maximum)
            {
                prePreparedGame.nextPlace();
                prePreparedProgress.Value = (int)prePreparedGame.place;
                whereAmIbox.Value = prePreparedGame.place;
            }
        }

        /// <summary>
        /// Turn on or of the prePreparedGame Section in the window
        /// </summary>
        /// <param name="b"></param>
        void prePreparedSection(bool b)
        {
            if (b)
            {
                showGame.Enabled = true;
                preparedSetButton.Enabled = true;
                previousItem.Enabled = true;
                nextItem.Enabled = true;
                stopPrePrepared.Enabled = true;
                whereAmIbox.Enabled = true;
                stopPrePrepared.Enabled = true;
            }
            else
            {
                showGame.Enabled = false;
                preparedSetButton.Enabled = false;
                previousItem.Enabled = false;
                nextItem.Enabled = false;
                stopPrePrepared.Enabled = false;
                whereAmIbox.Enabled = false;
                stopPrePrepared.Enabled = false;
                prePreparedProgress.Value = 0;
                whereAmIbox.Value = 0;                
            }
        }

        #endregion

        #endregion

        private void konsolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consoleForm.Show();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameConsole.clearHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            times.secondTimerStart();
        }
    }
}
