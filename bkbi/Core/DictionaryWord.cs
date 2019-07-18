using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkbi.Core
{
    class DictionaryWord : Questions
    {

        static List<string> Dictionary;
        public static string DictionaryPath { get; private set; }

        public DictionaryWord() : base()
        {
            Type = TypeEnum.DictionaryWord;

            UpdateMenuItem();
        }

        public static void changeDictionary(string path)
        {
            DictionaryPath = path;
            Dictionary = new List<string>(System.IO.File.ReadAllLines(DictionaryPath));
            foreach(Questions e in All)
            {
                if(e.GetType() == typeof(DictionaryWord))
                {
                    (e as DictionaryWord).UpdateMenuItem();
                    e.menuItem.ListView.Invalidate();
                }                
            }
        }

        protected override void UpdateMenuItem()
        {
            Summary = "Sözlük Yolu: " + DictionaryPath;
            base.UpdateMenuItem();
        }

        public override string[] GetCompetitionArray()
        {
            while (true)
            {
                try
                {
                    return Scramble(Dictionary[new Random().Next(0, Dictionary.Count + 1)].Split(null), 200, true);
                }
                catch (Exception ex)
                {
                    var r = System.Windows.Forms.MessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.RetryCancel);
                    if (r == System.Windows.Forms.DialogResult.Cancel) break;
                }
            }
            return null;
        }
                
    }
}
