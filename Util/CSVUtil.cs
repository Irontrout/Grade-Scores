using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grade_Scores.Model;

namespace Grade_Scores.Util
{
    public static class CSVUtil
    {
        /// <summary>
        /// Attempt to retreive a Student's information from an input string.
        /// </summary>
        public static IStudent GetStudentFromString(string input)
        {
            var segments = input?.Split(',').Select(p => p.Trim()).ToArray();

            if (segments == null || segments.Length != 3)
            {
                throw new StudentParsingException();
            }

            var firstName = segments[0];
            var surname = segments[1];
            var scoreParsed = int.TryParse(segments[2], out var score);

            if (string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(surname)
                || !scoreParsed)
            {
                throw new StudentParsingException();
            }

            return new Student(firstName, surname, score);
        }
    }
}
