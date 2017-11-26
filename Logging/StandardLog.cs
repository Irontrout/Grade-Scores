using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Grade_Scores.Util;

namespace Grade_Scores.Logging
{
    class StandardLog : Logger
    {
        // Constants
        private const string FILE_NAME = "grade-scores-log.log";


        // Constructors
        public StandardLog(string directory)
        {
            // Sanitise the directory in silent mode, because we can't actually
            // write to an unknown file yet.
            var dir = WindowsUtil.SanitiseDirectory(directory, this, false);
            
            // If we cannot sanitise, then use the temp directory instead.
            // This way we can always retrieve a log if need be.
            FilePath = dir != null ? 
                $"{directory}{FILE_NAME}" : 
                $"{Path.GetTempPath()}{FILE_NAME}";

            // If a log file already exists, then delete it.
            if (File.Exists(FilePath)) File.Delete(FilePath);
        }

        // Properties
        private string FilePath { get; }


        // Functions
        public override void Write(string message, LogCode code)
        {
            using (var fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                switch (code)
                {
                    case LogCode.INFO:
                        writer.WriteLine($"{message}");
                        break;
                    case LogCode.WARN:
                    case LogCode.ERR:
                        writer.WriteLine($"[{code}] - {message}");
                        break;

                }
            }
        }
    }
}
