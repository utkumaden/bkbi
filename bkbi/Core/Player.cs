using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace bkbi.Core
{
    /// <summary>
    /// A class made for representing players in the game.
    /// </summary>
    class Player
    {
        public static List<Player> All = new List<Player>();
        public int Id { get; private set; } = 0;
        public string Name { get; private set; }
        public int Points { get; private set; }
        public bool inGame { get; private set; } = true;
        public Bitmap PlayerIcon { get; private set; }
        public ListViewItem menuItem = new ListViewItem();

        public Player()
        {
            All.Add(this);

            Id = getNextId();

            Tools.Console.Info("Yeni oyuncu eklendi. (" + Id.ToString() + ")");

            UpdateMenuItem();
        }

        public static Player GetById(int id)
        {
            Tools.Console.Debug("Finding player by Id(id " + id.ToString() + ")");
            return All.Find(x => x.Id == id);
        }

        private void UpdateMenuItem()
        {
            menuItem.SubItems.Clear();
            menuItem.Text = Id.ToString();
            menuItem.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
                new ListViewItem.ListViewSubItem(menuItem, inGame ? "E" : "H"),
                new ListViewItem.ListViewSubItem(menuItem,Name),
                new ListViewItem.ListViewSubItem(menuItem, Points.ToString())
        });
        }

        public void Remove()
        {
            All.Remove(this);
            menuItem.Focused = false;
            menuItem.Remove();
            Reorder();
            Tools.Console.Info("Oyuncu " + Id + " kaldırıldı.");
        }

        public static void Reorder()
        {
            int i = 1;
            foreach(Player x in All)
            {
                x.Id = i;
                x.UpdateMenuItem();
                i++;
            }
            Tools.Console.Debug("Players reordered.");
        }

        public void setName(string name)
        {
            this.Name = name;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
            Tools.Console.Info("Oyuncu " + Id.ToString() + ": Ad: " + name);
        }

        public void addPoints(uint points)
        {
            this.Points = this.Points + (int)points;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
            Tools.Console.Info("Oyuncu " + Id.ToString() + ": " + points.ToString() + " puan eklendi.");
        }

        public void deductPoints(uint points)
        {
            this.Points = this.Points - (int)points;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
            Tools.Console.Info("Oyuncu " + Id.ToString() + ": " + points.ToString() + " puan kırıldı.");
        }

        public void setInGame(bool b)
        {
            inGame = b;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
            Tools.Console.Info("Oyuncu " + Id.ToString() + (inGame?" oyunda.":"oyunda değil.") );
        }

        public void setPP(Bitmap image)
        {
            PlayerIcon = image;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
            Tools.Console.Info("Oyuncu " + Id.ToString() + ": Resim değiştirilid.");
        }

        public static void idSetName(int id, string name)
        {
            GetById(id).setName(name);
        }

        public static void idAddPoints(int id, uint points)
        {
            GetById(id).addPoints(points);
        }

        public static void idDeductPoints(int id, uint points)
        {
            GetById(id).deductPoints(points);
        }

        public static void idSetIngame(int id, bool b)
        {
            GetById(id).setInGame(b);
        }

        public static void idSetPP(int id, Bitmap image)
        {
            GetById(id).setPP(image);
        }

        static int getNextId()
        {
            return All.Count;
        }

    }
}
