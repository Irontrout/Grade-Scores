using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Grade_Scores.Model;
using Grade_Scores.Util;

namespace Grade_Scores.ReaderWriters
{
    public abstract class StudentReader
    {
        protected StudentReader(string readFilePath)
        {
            ReadFilePath = readFilePath;

            // Set the write-to file path and clear any previous version of it.
            WriteFilePath = readFilePath.Remove(readFilePath.LastIndexOf(".", StringComparison.Ordinal)) +
                            "_Graded.txt";
            Util.WindowsUtil.ClearFilePath(WriteFilePath, null, false);

            Students = new List<IStudent>();
        }

        internal string ReadFilePath { get; }
        internal string WriteFilePath { get; }
        public IEnumerable<IStudent> Students { get; set; }

        public void Read()
        {
            Students = File.ReadAllLines(ReadFilePath)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(CSVUtil.GetStudentFromString)
                .ToArray();
        }

        public abstract void OrderStudents();

        public abstract void Write();
    }
}
