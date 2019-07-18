using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bir_Kelime_Bir_Islem
{
    class prePreparedGameHandler
    {
        #region Variables
        public gameItem selectedItem = new gameItem();
        public uint place = 0;
        public uint max;
        public bool loaded = false;
        XmlDocument game = new XmlDocument();
        setting settings = controlForm.settings;
        iConsoleLibrary.iConsole gameConsole = controlForm.gameConsole;
        
        #endregion
        
        /// <summary>
        /// Load a prePrepared Game 
        /// </summary>
        /// <param name="path">The path of the game</param>
        public void loadGame(string path)
        {
            try
            {
                game.Load(path);
            }
            catch (Exception ex) { throw new Exception("Can't access file, most likely doesn't exist", ex); gameConsole.writeErrorLine("[PPG] Can't access file, most likely doesn't exist"); }

            if (game.InnerXml == null)
            {
                throw new Exception("Game empty. Must be Broken.");
                gameConsole.writeErrorLine("[PPG] Game empty. Must be broken.");
            }

            if (game.SelectSingleNode("prePreparedGame/settings") != null)
            {                
                if (settings.getUseSettingsFromGames() && game.SelectNodes("prePreparedGame/settings/player") != null)
                {
                    if (settings.getUseArduino() && game.SelectSingleNode("prePreparedGame/settings/arduino") != null)
                    {
                        settings.setArduinoPort(game.SelectSingleNode("prePreparedGame/settings/arduino").Attributes.GetNamedItem("port").Value);
                    }
                    controlForm.P1.setName(game.SelectSingleNode("prePreparedGame/settings/player[@who='P1']").Attributes.GetNamedItem("name").Value);
                    controlForm.P2.setName(game.SelectSingleNode("prePreparedGame/settings/player[@who='P2']").Attributes.GetNamedItem("name").Value);
                    controlForm.P3.setName(game.SelectSingleNode("prePreparedGame/settings/player[@who='P3']").Attributes.GetNamedItem("name").Value);
                    controlForm.P1.setPoints(Int32.Parse(game.SelectSingleNode("prePreparedGame/settings/player[@who='P1']").Attributes.GetNamedItem("points").Value));
                    controlForm.P2.setPoints(Int32.Parse(game.SelectSingleNode("prePreparedGame/settings/player[@who='P2']").Attributes.GetNamedItem("points").Value));
                    controlForm.P3.setPoints(Int32.Parse(game.SelectSingleNode("prePreparedGame/settings/player[@who='P3']").Attributes.GetNamedItem("points").Value));
                }
            }
            loaded = true;
            max = (uint) game.SelectSingleNode("prePreparedGame/game").ChildNodes.Count;
            setPlace(1);
            gameConsole.writeLine("[PPG] Game Successfully Loaded", System.Drawing.Color.Green);
            
        }       

        /// <summary>
        /// Unload PrepreparedGame
        /// </summary>
        public void unload()
        {
            loaded = false;
            game = new XmlDocument();
            gameConsole.writeLine("[PPG] Game unloaded");
        }

        /// <summary>
        /// Loads the selected item
        /// </summary>
        private void loadItem()
        {
            if (game.SelectSingleNode("prePreparedGame/game").ChildNodes[(int)place - 1].Name == "word")
            {
                selectedItem.Value = game.SelectSingleNode("prePreparedGame/game").ChildNodes[(int)place - 1].InnerText as string;
                
            }
            if (game.SelectSingleNode("prePreparedGame/game").ChildNodes[(int)place - 1].Name == "equation")
            {
                string[] nums = (game.SelectSingleNode("prePreparedGame/game").ChildNodes[(int)place - 1].InnerText).Split(",".ToArray<char>());
                string sum = game.SelectSingleNode("prePreparedGame/game").ChildNodes[(int)place - 1].Attributes.GetNamedItem("sum").Value;
                selectedItem.Value = new object[] { sum, nums[0], nums[1], nums[2], nums[3], nums[4], nums[5] };
            }
            gameConsole.writeLine("[PPG] Game Item Loaded");
        }

        /// <summary>
        /// Sets which item is selected
        /// </summary>
        /// <param name="u"></param>
        public void setPlace(uint u)
        {
            if (loaded)
            {
                if (u == 0) throw new Exception("Cannot set the load place of game 0, it will crash the game.");
                if (u > max) throw new Exception("Cannot set value to " + u.ToString() + ", it is over the place count.");

                place = u;
                loadItem();
                gameConsole.writeLine("[PPG] Item Number: " + u.ToString());
            }
        }

        /// <summary>
        /// Loads the next item
        /// </summary>
        public void nextPlace()
        {
            if (loaded)
            {
                if (!(place >= max)) { place++; loadItem(); }
            }
        }

        /// <summary>
        /// Loads the previous item
        /// </summary>
        public void previous()
        {
            if (loaded)
            {
                if (!(place <= 1)) { place--; loadItem(); }
            }
        }

    }

    class gameType : IEquatable<gameType>
    {
        public string type = "";

        /// <summary>
        /// The word type for Game Type
        /// </summary>
        public static gameType Word { get { gameType a = new gameType(); a.type = "word"; return a; } }

        /// <summary>
        /// The Equation type for Game Type
        /// </summary>
        public static gameType Equation { get { gameType a = new gameType(); a.type = "equation"; return a; } }

        /// <summary>
        /// Checks if the types are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(gameType other)
        {
            if (type == other.type)
            {
                return true;
            }
            else return false;
        }
    }

    class gameItem
    {
        public gameType Type;
        string word;
        string sum;
        string a = "";
        string b = "";
        string c = "";
        string d = "";
        string e = "";
        string f = "";
        string[] values;


        public gameItem()
        {
            values = new string[] { a,b,c,d,e,f };
        }

        /// <summary>
        /// Checks wether values are numeric or not
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), System.Globalization.NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        }

        /// <summary>
        /// It is the value of the selected item. Can be a string(for word) or a string[](for equation)
        /// </summary>
        public object Value
        {
            get
            {
                if (Type.Equals(gameType.Word)) { return word; }
                else if (Type.Equals(gameType.Equation)) { return values; }
                else return null;
            }
            set
            {
                try
                {
                    Type = gameType.Equation;
                    if (!IsNumeric((value as object[])[0])) throw new Exception();
                }
                catch
                {
                    Type = gameType.Word;
                }
                finally
                {
                    try
                    {
                        if (Type.Equals(gameType.Word))
                        {
                            if ((value as string).Length > 8) throw new Exception("Argument is a word, but is longer than 8 characters");
                            word = value as string;
                            
                        }
                        if (Type.Equals(gameType.Equation))
                        {
                            object[] write = value as object[];
                            sum = write[0].ToString();
                            a = write[1].ToString(); 
                            b = write[2].ToString();
                            c = write[3].ToString();
                            d = write[4].ToString();
                            e = write[5].ToString();
                            f = write[6].ToString();
                            values = new string[] { sum,a,b,c,d,e,f};
                        }
                    }
                    catch { throw new ArgumentException(); }
                }
            }
        }

    }

}
