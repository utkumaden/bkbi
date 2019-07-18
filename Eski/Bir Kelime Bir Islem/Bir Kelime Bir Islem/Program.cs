using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static controlForm mainform;
        static string gamepath = Environment.GetEnvironmentVariable("appdata")+ @"\Bir Kelime Bir İşlem";
        public static Bir_Kelime_Bir_Islem.Forms.Main.console consoleForm; 

        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            
            pathSetup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainform = new controlForm();
            consoleForm = new Forms.Main.console();
            try
            {
                if (File.Exists(args[1]))
                {
                    mainform.iLoader(args[1]);
                }                
            }
            catch { }

            try
            {
                if (File.Exists(args[2])&&args[1]!="-list")
                {
                    mainform.iLoader(args[2]);
                }
            }
            catch { }

            if (args.Length == 3)
            {
                if (args[1] == "-list" && File.Exists(args[2]))
                {
                    Application.Run(new Bir_Kelime_Bir_Islem.Forms.List.lister(args[2]));
                }
            }                
            else
            {
                Application.Run(mainform);
            }
            
        }
        static void pathSetup()
        {
            if (!Directory.Exists(gamepath))
            {
                Directory.CreateDirectory(gamepath);
            }
            if (!Directory.Exists(gamepath + @"\iConsole"))
            {
                Directory.CreateDirectory(gamepath + @"\iConsole");
            }
        }

    }
}
