namespace Grade_Scores
{
    public static class Exceptions
    {
        /// <summary>
        /// Write an error message to the log or console.
        /// </summary>
        /// <param name="message"></param>
        public static void ThrowException(string message)
        {
            Log.DebugWriteLine($"ERROR: {message}");
        }

        /// <summary>
        /// Get an Incorrect student error message
        /// </summary>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        public static string WrongStudentDataInput(string inputLine)
        {
            return
                $"The data line of [{inputLine}] is incorrect. Please set line to be [FirstName], [LastName], [Score]";
        }

        /// <summary>
        /// Get a "File not exist" error message
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DataFileDoesntExist(string input)
        {
            return
                $"The file \"{input}\" does not exist.";
        }
    }
}
