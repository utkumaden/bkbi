using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bir_Kelime_Bir_Islem
{
    class silentPrePreparedGameHandler
    {
        #region Variables
        public gameItem selectedItem = new gameItem();
        public uint place = 0;
        public uint max;
        public bool loaded = false;
        XmlDocument game = new XmlDocument();

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
            catch (Exception ex) { throw new Exception("Can't access file, most likely doesn't exist", ex); }

            if (game.InnerXml == null)
            {
                throw new Exception("Game empty. Must be Broken.");
            }

            loaded = true;
            max = (uint)game.SelectSingleNode("prePreparedGame/game").ChildNodes.Count;
            setPlace(1);

        }

        /// <summary>
        /// Unload PrepreparedGame
        /// </summary>
        public void unload()
        {
            loaded = false;
            game = new XmlDocument();
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
}