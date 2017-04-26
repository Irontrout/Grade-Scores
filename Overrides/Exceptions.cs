using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grade_Scores
{
    public static class Exceptions
    {
        public static void ThrowException(string message)
        {
            Log.DebugWriteLine($"ERROR: {message}");
        }

        public static string WrongStudentDataInput(string inputLine)
        {
            return
                $"The data line of [{inputLine}] is incorrect. Please set line to be [FirstName], [LastName], [Score]";
        }

        public static string DataFileDoesntExist(string input)
        {
            return
                $"The file \"{input}\" does not exist.";
        }
    }
}
