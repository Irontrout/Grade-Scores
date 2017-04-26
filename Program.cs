using System;
using CommandLine;

namespace Grade_Scores
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            // If no values are input, then close.
            if (!Parser.Default.ParseArguments(args, options)) Log.DebugWriteLine(options.GetUsage());

            // Set input file and read the students from it.
            var file = new DataCSV(options.InputFile);
            if (!file.FileExists)
            {
                Log.WriteLogToFile();
                return;
            }
            var students = new StudentList(file.CSV);
            
            // Output the file with the students.
            file.WriteOutputCSV(students);

            Log.WriteLogToFile();
            Log.DebugWaitForInput();
        }
    }
}
