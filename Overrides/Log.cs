using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Grade_Scores
{
    public class Log
    {
        internal static string log = string.Empty;

        /// <summary>
        /// Write a string to console if running in debug mode.
        /// </summary>
        public static void DebugWrite(string input)
        {
            if (Debugger.IsAttached)
            {
                Console.Write(input);
            }
            else
            {
                log += input;
            }
        }

        /// <summary>
        /// Write a string on a new line if running in debug mode.
        /// </summary>
        public static void DebugWriteLine(string input)
        {
            DebugWrite($"{Environment.NewLine}{input}");
        }

        public static void DebugAddEmptyLine()
        {
            DebugWriteLine(string.Empty);
        }

        /// <summary>
        /// Write a prefix message and wait for the user to respond.
        /// </summary>
        /// <param name="prefixMessage"></param>
        public static void DebugWaitForInput()
        {
            if (!Debugger.IsAttached) return;

            DebugAddEmptyLine();
            DebugAddEmptyLine();
            Console.WriteLine("Press any key to close...");
            Console.Read();
        }

        public static void WriteLogToFile()
        {
            // If there is nothing to log, do nothing.
            if (string.IsNullOrEmpty(log)) return;

            var logOutput = $@"{Environment.CurrentDirectory}/Grade-Scores-Log.txt";
            log = $"Log written [{DateTime.Now}]{log}";


            // If there is information to log, write it down.
            using (var output = new StreamWriter(logOutput))
            {
                output.WriteLine(log);
            }

            MessageBox.Show(
                $"There were errors in the export, please see the logs at {logOutput} for more details",
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
