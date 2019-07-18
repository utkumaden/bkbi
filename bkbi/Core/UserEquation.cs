using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkbi.Core
{
    class UserEquation : Questions
    {
        public int[] numbers { get; private set; } = new int[6];
        public int sum { get; private set; } = 0;
        public string solve { get; private set; }

        public UserEquation() : base()
        {
            Type = TypeEnum.UserEquation;

            UpdateMenuItem();
        }

        protected override void UpdateMenuItem()
        {
            Summary = string.Join("|", numbers) + "=" + sum.ToString();
            base.UpdateMenuItem();
        }

        public void set(int sum, string solve, int[] numbers)
        {
            this.sum = sum;
            this.solve = solve;
            this.numbers = numbers;
            UpdateMenuItem();
            menuItem.ListView.Invalidate();
        }

        public override string[] GetCompetitionArray()
        {
            while (true)
            {
                try
                {
                    if (numbers != null)
                    {
                        List<string> chars = new List<string>();
                        for (int i = 0; i<numbers.Length; i++)
                        {
                            if(i != (numbers.Length-1)) chars.Add(numbers[i].ToString());
                        }
                        //foreach(int i in numbers)
                        //{
                        //    chars.Add(i.ToString());
                        //}
                        string[] a = Scramble(chars.ToArray(), 200, false);
                        chars = new List<string>();
                        chars.AddRange(a);
                        chars.Add(numbers[numbers.Length - 1].ToString());
                        chars.Add("=");
                        chars.Add(sum.ToString());
                        return chars.ToArray();
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