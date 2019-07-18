using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkbi.Tools
{
    public static class Console
    {

        static string template = "[ %type @ %time ] %msg\n";
        struct TypeStrings
        {
            public static string @Debug = "AYKLM";
            public static string @Info = "BİLGİ";
            public static string @Warning = "UYARI";
            public static string @Error = "HATA";
            public static string @Fatal = "ÇÖKME";
        }

        static bool WriteToLog = true;
        static bool WriteToOSConsole = true;

        [Conditional("DEBUG")]
        public static void Debug(object @object)
        {
            Write(GetHeader(TypeStrings.Debug, @object));
        }

        public static void Info(object @object)
        {
            Write(GetHeader(TypeStrings.Info, @object));
        }

        public static void Warning(object @object)
        {
            Write(GetHeader(TypeStrings.Warning, @object));
        }

        public static void Error(object @object)
        {
            Write(GetHeader(TypeStrings.Error, @object));
        }

        public static void Fatal(object @object)
        {
            Write(GetHeader(TypeStrings.Fatal, @object));
        }

        public static void CommandWrite(object @object, bool firstChars = true)
        {
            Write(firstChars ? ">" + @object : @object);
        }

        public static void CommandWriteLine(object @object)
        {
            CommandWrite(@object + "\n");
        }

        delegate void AppInvoke(object a);
        static AppInvoke invoker = new AppInvoke(AppendInvoker);
        static void Write(object @object)
        {
            if (WriteToOSConsole) System.Console.Write(@object);
            if (WriteToLog) ;//TODO: ADD LOG HANDLING

            Program.ControlPanel.consoleRichTextBox.Invoke(invoker, @object);
        }

        static void AppendInvoker(object @object)
        {
            Program.ControlPanel.consoleRichTextBox.AppendText(@object.ToString());
        }

        static string GetHeader(string typeString, object @object)
        {
            string toReturn = template;
            toReturn = toReturn.Replace("%type", typeString);
            toReturn = toReturn.Replace("%time", DateTime.Now.ToLongTimeString());
            toReturn = toReturn.Replace("%msg", @object.ToString());
            return toReturn;
        }
    }
}
