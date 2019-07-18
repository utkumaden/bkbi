using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bkbi.Core
{
    abstract class Questions
    {
        public static List<Questions> All = new List<Questions>();
        public int Id { get; protected set; }
        public enum TypeEnum
        {
            DictionaryWord,
            UserWord,
            AutoEquation,
            UserEquation
        }
        public TypeEnum Type { get; protected set; }
        public string Summary;
        public bool Used { get; private set;} = false;
        public ListViewItem menuItem { get; protected set; } = new ListViewItem();
        public uint MaximumWorthInPoints = 20;

        public Questions()
        {
            All.Add(this);
            Id = GetNextId();
            Tools.Console.Info("Yeni soru eklendi. (" + Id.ToString() + ")");
            UpdateMenuItem();
        }

        public static Questions GetById(int id)
        {
            Tools.Console.Debug("Finding Question by Id(id " + id.ToString() + ")");
            return All.Find(x => x.Id == id);
        }

        protected static int GetNextId()
        {
            return All.Count;
        }

        public void SetUsed(bool b)
        {
            Tools.Console.Info("Soru " + Id + " " + ((b) ? "kullanıldı." : "kullanılmadı."));
            Used = b;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
        }

        public void SetWorth(uint points)
        {
            Tools.Console.Info("Soru " + Id + " " + points.ToString() + " puan değerinde." );
            MaximumWorthInPoints = points;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
        }

        public static int GetDeltaWorth(int points, int currentTime, int sigmaTime)
        {
            if (((float)currentTime / (float)sigmaTime )> ((float)2 / (float)3)||currentTime == -1)
            {
                return points;
            }
            else if ( (float) (((float)currentTime) / ((float)sigmaTime)) > ((float)(float)1 / (float)3))
            {
                return 3 * points / 4;
            }
            else return points / 2;
        }

        public void Remove()
        {
            All.Remove(this);
            menuItem.Focused = false;
            menuItem.Remove();
            Reorder();
            Tools.Console.Info("Soru " + Id + " kaldırıldı.");
        }

        private static void Reorder()
        {
            int i = 1;
            foreach(Questions x in All)
            {
                x.Id = i;
                x.UpdateMenuItem();
                i++;
            }
            Tools.Console.Debug("Questions reordered.");
        }

        protected virtual void UpdateMenuItem()
        {
            menuItem.SubItems.Clear();
            menuItem.Text = Id.ToString();
            menuItem.ImageIndex = (int)Type;
            string x;
            switch(Type){
                case TypeEnum.AutoEquation:
                    x = "Otomatik İşlem";
                    break;
                case TypeEnum.DictionaryWord:
                    x = "Sözlük Kelimesi";
                    break;
                case TypeEnum.UserEquation:
                    x = "Kullamıcı İşlemi";
                    break;
                case TypeEnum.UserWord:
                    x = "Kullanıcı Kelimesi";
                    break;
                default:
                    x = "HATA";
                    break;
            }
            menuItem.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
            {
                new ListViewItem.ListViewSubItem(menuItem, Used ? "E" : "H"),
                new ListViewItem.ListViewSubItem(menuItem, x),
                new ListViewItem.ListViewSubItem(menuItem, MaximumWorthInPoints.ToString()),
                new ListViewItem.ListViewSubItem(menuItem, Summary)
            });
            Tools.Console.Debug("Question " + Id.ToString() + "'s menu item reordered.");
        }

        public abstract string[] GetCompetitionArray();

        #region Scrambler
        protected static string[] Scramble(string[] array, int maxTries, bool check)
        {
            Tools.Console.Info("Karıştırma işlemi: " + string.Join("", array) + ", " + maxTries.ToString() + " deneme, kontrol " + check.ToString());
            string[] toReturn = new string[array.Length];
            Random r = new Random();
            int tries = 0;
            bool flag = true;
            bool checkFine = false;
            while (flag)
            {
                Tools.Console.Info("Karıştırma İşlemi: Deneme " + tries);
                if (tries > maxTries)
                {
                    Tools.Console.Info("Karıştırma işlemi başarısız. :(");
                    toReturn = new string[] { "H","A","T","A","L","I","!","!" };
                    break;
                }
                var list = new SortedList<int, string>();
                foreach (var c in array)
                    list.Add(r.Next(), c);
                toReturn = list.Values.ToArray();

                if (check)
                {
                    if (CheckScramble(array, toReturn))
                    {
                        checkFine = true;
                    }
                }
                else
                {
                    checkFine = true;
                }

                if (checkFine)
                {
                    flag = false;
                    Tools.Console.Warning("Karıştırma işlemi başarılı!");
                }
                else { tries++; }
            }

            return toReturn;
        }

        static bool CheckScramble(string[] actual, string[] result)
        {
            //Check scramble
            string[] checkchars;
            string[] checkchars2;
            bool success = true;
            for (int i = 0; i < actual.Length - 2; i++)
            {
                checkchars = new string[] { actual[i], actual[i + 1], actual[i+2] };
                for (int ii = 0; ii < actual.Length - 2; ii++)
                {
                    checkchars2 = new string[] { result[ii], result[ii + 1], result[ii+2] };
                    if (checkchars[0] == checkchars2[0] && checkchars[1] == checkchars2[1] && checkchars[2] == checkchars2[2])
                    {
                        success = false;
                        break;
                    }
                }
                if (!success) break;
            }

            if (success)
            {
                Tools.Console.Info("Karıştırma İşlemi: Kontrolden geçildi.");
            }
            else
            {
                Tools.Console.Warning("Karıştırma İşlemi: Kontrolden geçilemedi.");
            }

            return success;
        }
        #endregion

    }
}