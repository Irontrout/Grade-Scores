using System;
using System.Diagnostics;
using CommandLine;
using Grade_Scores.Logging;
using Grade_Scores.Util;

namespace Grade_Scores
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            ILog logger;

            // Initilise the logger.
            if (Debugger.IsAttached)
            {
                //logger = new DebugLog();
                logger = new StandardLog(AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                logger = new StandardLog(AppDomain.CurrentDomain.BaseDirectory);
            }

            // If no values are input, then close.
            if (!Parser.Default.ParseArguments(args, options))
            {
                logger.Write(options.GetUsage());
                Environment.Exit((int) ExitCode.InvalidArgument);
            }
            else
            {
                RunMain(options, logger);
            }
        }

        private static void RunMain(Options options, ILog logger)
        {
            // Read the file specified.
            MainRunner.Run(options.InputFile, logger);
        }
    }

    internal enum ExitCode
    {
        Successful,
        InvalidArgument
    }
}
