using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace bkbi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            bool debug = false;
            bool isPreview = false;
            bool isHelp = false;
            bool isGuiHelp = false;
            bool isVersion = false;
            string path = "";
            if (args.Length == 1)
            {
                start(false);
            }
            else
            {                
                foreach (string arg in args.ToList().GetRange(1, args.Length - 1))
                {
                    if (arg == "-d" || arg == "--debug") debug = true;
                    if (arg == "-p" || arg == "--preview") isPreview = true;
                    if (arg == "-h" || arg == "--help") isHelp = true;
                    if (arg == "-gh" || arg == "--guihelp") isGuiHelp = true;
                    if (arg == "-v" || arg == "--version") isVersion = true;
                    if (File.Exists(arg)) path = arg;

                }

                if (isHelp) help(debug);
                else if (isGuiHelp) ghelp(debug);
                else if (isVersion) version(debug);
                else if (isPreview && path != string.Empty && File.Exists(path)) viewPrePreparedGame(path, debug);
                else if (path != string.Empty && File.Exists(path)) startPrePreparedGame(path, debug);
                else start(debug);
            }

            int[] x;            
        }

        public static Forms.ControlPanel.ControlPanel ControlPanel;
        /// <summary>
        /// Function to start the program regularly
        /// </summary>
        /// <param name="debug">Run the program in debug mode?</param>
        static void start(bool debug)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            ControlPanel = new Forms.ControlPanel.ControlPanel();
            if (debug)
            {
                Application.Run(ControlPanel);
            }
            else
            {
#if __WIN32__
                ShowWindow(GetConsoleWindow(), 0);
#endif
                try
                {
                    Application.Run(ControlPanel);
                }
                catch (Exception ex)
                {
                    Application.Run(new Forms.Errors.ExceptionReporter(ex, 10));
                }          
            }
        }

        /// <summary>
        /// [CommandLine] Function Show Help Text
        /// </summary>
        /// <param name="debug">Run the program in debug mode? (Like there are things to debug...)</param>
        static void help(bool debug)
        {
            Console.WriteLine(@"bkbi Help:
Usage: bkbi [-d/--debug] [operators] [path]
    -d --debug    | Start the application in debug mode.
Operators:
    -v --version         | Views the version of the program.
    -h --help            | View commandline help. (this operator)
    -gh --guihelp        | View help GUI.
    -p --preview         | Preview a preprepared game.
No Operators + path      | Load the preprepared game the path points to.
No Operators and no path |Launch normally");            
        }

        /// <summary>
        /// [GUI] Run the Help Dialog
        /// </summary>
        /// <param name="debug">Run the program in debug mode?</param>
        static void ghelp(bool debug)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            if (debug)
            {

            }
            else
            {
#if __WIN32__
                ShowWindow(GetConsoleWindow(), 0);
#endif
                try
                {

                }
                catch (Exception ex)
                {
                    Application.Run(new Forms.Errors.ExceptionReporter(ex, 10));
                }
            }
        }

        /// <summary>
        /// [CommandLine] Write Version to commandline.
        /// </summary>
        /// <param name="debug">Run the program in debug mode?</param>
        static void version(bool debug)
        {
            Console.WriteLine("bkbi Verion:" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        /// <summary>
        /// [GUI] View the preprepared game.
        /// </summary>
        /// <param name="debug">Run the program in debug mode?</param>
        static void viewPrePreparedGame(string path, bool debug)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            ControlPanel = new Forms.ControlPanel.ControlPanel();
            if (debug)
            {
                ControlPanel.Show();
                Core.SaveLoad.Load(path);
                Application.Run();
            }
            else
            {
#if __WIN32__
                ShowWindow(GetConsoleWindow(), 0);
#endif
                try
                {
                    Core.SaveLoad.Load(path);
                    Application.Run(ControlPanel);
                }
                catch (Exception ex)
                {
                    Application.Run(new Forms.Errors.ExceptionReporter(ex, 10));
                }
            }
        }

        /// <summary>
        /// [GUI] Run the prepepared game.
        /// </summary>
        /// <param name="debug">Run the program in debug mode?</param>
        static void startPrePreparedGame(string path, bool debug)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            ControlPanel = new Forms.ControlPanel.ControlPanel();
            if (debug)
            {
                ControlPanel.Show();
                Core.SaveLoad.Load(path);
                Application.Run();
            }
            else
            {
#if __WIN32__
                ShowWindow(GetConsoleWindow(), 0);
#endif
                try
                {
                    Core.SaveLoad.Load(path);
                    Application.Run(ControlPanel);
                }
                catch (Exception ex)
                {
                    Application.Run(new Forms.Errors.ExceptionReporter(ex, 10));
                }
            }
        }

#if __WIN32
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int Handle, int showState);
        [DllImport("kernel32.dll")]
        public static extern int GetConsoleWindow();
#endif
    }
}
