using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkbi.Core
{ 
    class AutoEquation : Questions
    {

        public int[] numbers;
        public int sum;
        public string solve;

        public AutoEquation() : base()
        {
            Type = TypeEnum.AutoEquation;

            UpdateMenuItem();
        }

        enum ArithmeticOP
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private void generate()
        {
            int[] nums = new int[8];
            ArithmeticOP[] ops = new ArithmeticOP[7];
            int s = 0; 
            string solv = "";
            Random r = new Random();

            for(int i = 0; i<8; i++)
            {
                nums[i] = r.Next(1, 10);
            }

            for (int i = 0; i < 7; i++)
            {
                switch(r.Next(0, 4))
                {
                    case 0:
                        ops[i] = ArithmeticOP.Addition;
                        break;
                    case 1:
                        ops[i] = ArithmeticOP.Subtraction;
                        break;
                    case 2:
                        ops[i] = ArithmeticOP.Multiplication;
                        break;
                    case 3:
                        ops[i] = ArithmeticOP.Division;
                        break;
                    default:
                        break;
                         
                }
            }

            numbers = nums;

            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    switch(ops[i])
                    {
                        case ArithmeticOP.Addition:
                            solv = solv + nums[i].ToString() + "+" + nums[i + 1].ToString() + "=";
                            s = nums[i] + nums[i +1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Subtraction:
                            solv = solv + nums[i].ToString() + "-" + nums[i + 1].ToString() + "=";
                            s = nums[i] - nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Multiplication:
                            solv = solv + nums[i].ToString() + "\x00D7" + nums[i + 1].ToString() + "=";
                            s = nums[i] * nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Division:
                            solv = solv + nums[i].ToString() + "\x00F7" + nums[i + 1].ToString() + "=";
                            s = nums[i] / nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                    }
                }
                else
                {
                    switch (ops[i])
                    {
                        case ArithmeticOP.Addition:
                            solv =  solv + nums[i].ToString() + "+" + nums[i + 1].ToString() + "=";
                            s = s + nums[i+1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Subtraction:
                            solv = solv + nums[i].ToString() + "-" + nums[i + 1].ToString() + "=";
                            s = s - nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Multiplication:
                            solv = solv + nums[i].ToString() + "\x00D7" + nums[i + 1].ToString() + "=";
                            s = s * nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                        case ArithmeticOP.Division:
                            solv = solv + nums[i].ToString() + "\x00F7" + nums[i + 1].ToString() + "=";
                            s = s / nums[i + 1];
                            solv = solv + s.ToString() + "\n";
                            break;
                    }
                }
            }
            solve = solv;
            sum = s;
        }

        public override string[] GetCompetitionArray()
        {
            generate();
            while (true)
            {
                try
                {
                    if (numbers != null)
                    {
                        List<string> chars = new List<string>();
                        foreach(int i in numbers)
                        {
                            chars.Add(i.ToString());
                        }
                        string[] a = Scramble(chars.ToArray(), 200, false);
                        chars = new List<string>();
                        chars.AddRange(a);
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