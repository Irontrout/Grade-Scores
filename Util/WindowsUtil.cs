using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Grade_Scores.Logging;

namespace Grade_Scores.Util
{
    public static class WindowsUtil
    {
        /// <summary>
        /// Ensure that the directory exists and is returned with a standard folder escape.
        /// REVIEWER NOTE: This is a bit over the top, but a good reason to use a regex.
        /// </summary>
        /// <returns>A sanitised directory path.</returns>
        public static string SanitiseDirectory(string directory, ILog logger, bool verbose = true)
        {
            if (!Directory.Exists(directory))
            {
                if (verbose) logger.Write($"The directory \"{directory}\" does not exist.", LogCode.ERR);
                return null;
            }

            // If the directory does not have the standard folder escape, then add one
            if (!Regex.IsMatch(directory, @"\\{2}$"))
            {
                if (verbose) logger.Write($"The directory does not have a folder escape", LogCode.WARN);
                return directory + @"\\";
            }

            return directory;
        }

        /// <summary>
        /// Ensure that the file does not exist
        /// REVIEWER NOTE: This is a bit over the top, but a good reason to use a regex.
        /// </summary>
        public static void ClearFilePath(string filePath, ILog logger, bool verbose = true)
        {
            if (File.Exists(filePath))
            {
                if (verbose) logger.Write($"The file \"{Path.GetFileName(filePath)}\" already existed and has been removed..", LogCode.WARN);

                File.Delete(filePath);
            }

            return;
        }
    }
}
