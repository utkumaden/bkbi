using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkbi.Core
{
    class UserWord : Questions
    {
        public string Word { get; private set; } = null;

        public UserWord() : base()
        {
            Type = TypeEnum.UserWord;
            UpdateMenuItem();
        }

        protected override void UpdateMenuItem()
        {
            Summary = string.Join("",Word);
            base.UpdateMenuItem();
        }

        public void setUserWord(string words)
        {
            Word = words;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
        }

        public override string[] GetCompetitionArray()
        {
            while (true)
            {
                try
                {
                    if (Word != null)
                    {
                        List<string> x = new List<string>();
                        foreach(char a in Word.ToCharArray())
                        {
                            x.Add(a.ToString());
                        }
                        return Scramble(x.ToArray(), 200, true);
                    }
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
