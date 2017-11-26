using System;
using System.Diagnostics;
using System.IO;
using Grade_Scores.Logging;

namespace Grade_Scores
{
    public abstract class Logger : ILog
    {
        /// <summary>
        /// Write an information message
        /// </summary>
        public virtual void Write(string message)
        {
            Write(message, LogCode.INFO);
        }

        public abstract void Write(string message, LogCode code);
    }

    //public sealed class Log
    //{
    //    // --------------
    //    // Singleton code
    //    private static readonly Lazy<Log> Manager = new Lazy<Log>(() => new Log());
    //    public static Log Instance => Manager.Value;

    //    internal static string log = String.Empty;

    //    /// <summary>
    //    /// Write a string to console if running in debug mode.
    //    /// </summary>
    //    public static void LogWrite(string input)
    //    {
    //        if (Debugger.IsAttached)
    //        {
    //            Console.Write(input);
    //        }
    //        else
    //        {
    //            log += input;
    //        }
    //    }

    //    /// <summary>
    //    /// Write a string on a new line if running in debug mode.
    //    /// </summary>
    //    public static void LogWriteLine(string input)
    //    {
    //        LogWrite($"{Environment.NewLine}{input}");
    //    }

    //    /// <summary>
    //    /// Write an error message to the log or console.
    //    /// </summary>
    //    /// <param name="message"></param>
    //    public static void LogError(string message)
    //    {
    //        Log.LogWriteLine($"ERROR: {message}");
    //    }

    //    /// <summary>
    //    /// Write a prefix message and wait for the user to respond.
    //    /// </summary>
    //    public static void DebugWaitForInput(string message)
    //    {
    //        if (!Debugger.IsAttached) return;
            
    //        LogWriteLine($"{Environment.NewLine}");
    //        Console.WriteLine($"{message}");
    //        Console.Read();
    //    }

    //    /// <summary>
    //    /// Write the whole log to a file.
    //    /// </summary>
    //    public static void WriteLogToFile(string logMessagePrefix)
    //    {
    //        // If there is nothing to log, do nothing.
    //        if (String.IsNullOrEmpty(log)) return;

    //        var logOutput = $@"{Environment.CurrentDirectory}/Grade-Scores-Log.txt";
    //        log = $"{logMessagePrefix}{log}";


    //        // If there is information to log, write it down.
    //        using (var output = new StreamWriter(logOutput))
    //        {
    //            output.WriteLine(log);
    //        }
    //    }
    //}
}
