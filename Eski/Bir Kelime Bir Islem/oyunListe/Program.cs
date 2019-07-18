using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunListe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                Application.Run(new Bir_Kelime_Bir_Islem.Forms.List.lister(args[1]));
            }
            else
            {
                Application.Run(new Bir_Kelime_Bir_Islem.Forms.List.lister());
            }
        }
    }
}
