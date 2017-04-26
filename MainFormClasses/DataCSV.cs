using System;
using System.IO;

namespace Grade_Scores
{
    internal class DataCSV
    {
        internal DataCSV(string file)
        {
            CSV = GetFile(file);
        }

        internal void WriteOutputCSV(StudentList studentList)
        {
            using (StreamWriter output = new StreamWriter($@"{FileDirectory}\{FileName}-Graded.txt"))
            {
                foreach (var student in studentList.OrderedStudents)
                {
                    output.WriteLine(student.OrderedFullLine);
                }
            }
        }

        internal string CSV { get; }

        internal bool FileExists => File.Exists(CSV);

        private string FileDirectory
        {
            get
            {
                var path = Path.GetDirectoryName(CSV);
                return string.IsNullOrEmpty(path) ? Environment.CurrentDirectory : path;
            }
        }

        private string FileName => Path.GetFileNameWithoutExtension(CSV);

        private static string GetFile(string value)
        {
            // If the file exists as is, then return as is.
            if (File.Exists(value))
            {
                return value;
            }

            // If the file is in the directory of where the command line is pointed at.
            var file = $"{Environment.CurrentDirectory}/{value}";
            if (File.Exists(file))
            {
                return file;
            }

            // if the file doesn't exist, throw an exception and return nothing.
            Exceptions.ThrowException(Exceptions.DataFileDoesntExist(value));
            return string.Empty;
        }
    }
}
