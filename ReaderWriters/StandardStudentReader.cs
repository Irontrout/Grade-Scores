using System;
using System.IO;
using System.Linq;

namespace Grade_Scores.ReaderWriters
{
    public class StandardStudentReader : StudentReader
    {
        public StandardStudentReader() : base()
        {
        }

        public StandardStudentReader(string readFilePath) : base(readFilePath)
        {
        }

        public override void OrderStudents()
        {
            Students = Students.OrderByDescending(x => x.Score)
                .ThenBy(x => x.LastName, StringComparer.InvariantCultureIgnoreCase)
                .ThenBy(x => x.FirstName, StringComparer.InvariantCultureIgnoreCase);
        }

        public override void Write()
        {
            File.WriteAllLines(WriteFilePath, Students.Select(s=>s.GetDetails()));
        }
    }
}
