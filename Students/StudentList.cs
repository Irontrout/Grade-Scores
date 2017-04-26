using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grade_Scores
{
    internal class StudentList
    {
        private List<Student> Students { get; }

        /// <summary>
        /// Creates a list of students that can be manipulated
        /// </summary>
        /// <param name="inputFile"></param>
        internal StudentList(string inputFile)
        {
            Students = ReadStudentsFromFile(inputFile);
        }

        /// <summary>
        /// Gets the ordered list of students (How we expect them to be seen on the output file)
        /// </summary>
        internal List<Student> OrderedStudents
        {
            get
            {
                return Students.OrderByDescending(s => s.Score)
                    .ThenBy(s => s.LastName, StringComparer.InvariantCultureIgnoreCase)
                    .ThenBy(s => s.FirstName, StringComparer.InvariantCultureIgnoreCase)
                    .ToList();
            }
        }

        /// <summary>
        /// Attempt to read the students from a given input file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private static List<Student> ReadStudentsFromFile(string inputFile)
        {
            var students = File.ReadAllLines(inputFile)
                .Select(ExtractInformationFromInputAndCreateStudent)
                .Where(s => s.FirstName != null || s.LastName != null)
                .ToList();

            return students;
        }

        /// <summary>
        /// Extract a student from a string (Line from input file)
        /// </summary>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        internal static Student ExtractInformationFromInputAndCreateStudent(string inputLine)
        {
            // Split each segment into seperable parts.
            var split = inputLine.Split(',');

            // If there are more or less values than 3, then the data is incorrect, throw exception and return nothing.
            if (split.Length != 3)
            {
                return ThrowIncorrectDataAndReturnEmptyStudent(inputLine);
            }

            var firstName = split[0].Trim();
            var lastName = split[1].Trim();
            int score;

            // If the score value cannot be parsed to an int, then something is wrong, throw and return empty;
            if (!int.TryParse(split[2].Trim(), out score)) return ThrowIncorrectDataAndReturnEmptyStudent(inputLine);

            // If we've got good data, then let's set some values and create a student to return.
            return new Student(firstName, lastName, score);
        }

        private static Student ThrowIncorrectDataAndReturnEmptyStudent(string inputLine)
        {
            Exceptions.ThrowException(Exceptions.WrongStudentDataInput(inputLine));
            return new Student();
        }
    }
}
