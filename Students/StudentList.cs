using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Grade_Scores
{
    internal class StudentList
    {
        private List<Student> Students { get; }

        internal StudentList(string inputFile)
        {
            Students = ReadStudentsFromFile(inputFile);
        }

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

        private static List<Student> ReadStudentsFromFile(string inputFile)
        {
            var students = File.ReadAllLines(inputFile)
                .Select(ExtractInformationFromInputAndCreateStudent)
                .Where(s => s.FirstName != null || s.LastName != null)
                .ToList();

            return students;
        }

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
