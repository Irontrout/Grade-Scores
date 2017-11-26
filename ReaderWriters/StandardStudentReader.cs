using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grade_Scores.Model;

namespace Grade_Scores.ReaderWriters
{
    class StandardStudentReader : StudentReader
    {
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
