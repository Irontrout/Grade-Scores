using System.Collections.Generic;
using System.Linq;
using Grade_Scores;
using NUnit.Framework;

namespace GradeScoresTests
{
    [TestFixture]
    public class StudentsTests
    {
        [TestCase("Abigail, Aaronson, 20", false)] // Same Score, Earlier both names
        [TestCase("Zander, Zandinson, 20", true)] // Same Score, later both names
        [TestCase("Gary, Aaronson, 20", false)] // Same Score + first name, earlier last name
        [TestCase("Gary, Zandinson, 20", true)] // Same Score + First name, later last name
        [TestCase("Abigail, Garrison, 20", false)] // Same Score + Last name, earlier first name
        [TestCase("Zander, Garrison, 20", true)] // Same Score + Last name, later first name
        [TestCase("Gary, Garrison, 25", false)] // Same First name + last name, higher score
        [TestCase("Gary, Garrison, 15", true)] // Same First name + last name, lower score
        public void OrderedOutputTest(string inputStudent, bool isKeyFirstOnList)
        {
            // Assign
            // The key student
            var keyStudent = ExtractStudentFromString("Gary, Garrison, 20");

            // Mock an input file with both input and key student
            TestHelpers.MockInputFileFromString(new List<string> {keyStudent.StandardFullLine, inputStudent});
            var students = new StudentList(TestHelpers.TestFile);

            // Act / Assert
            // Assert whether the key student should be the first student or not.
            Assert.AreEqual(students.OrderedStudents.First().Equals(keyStudent), isKeyFirstOnList);
        }

        [TestCase("Gary, Garrison, 15", true)] // Expected
        [TestCase("Gary, Garrison", false)] // Too few arguments
        [TestCase("Gary, 15", false)] // Too few arguments
        [TestCase("Gary, Garrison, WORD", false)] // String where int should be
        [TestCase("Gary, Garrison, 15, WORD", false)] // too many arguments.
        public void LogFailedStudents(string inputStudent, bool logIsEmpty)
        {
            // Assign / Act
            var students = ExtractStudentFromString(inputStudent);

            // Assert
            Assert.AreEqual(students.StandardFullLine.Equals(inputStudent), logIsEmpty);
            Assert.AreEqual(string.IsNullOrEmpty(Log.log), logIsEmpty);
        }

        private Student ExtractStudentFromString(string input)
        {
            return StudentList.ExtractInformationFromInputAndCreateStudent(input);
        }

        [TearDown]
        public void TearDown()
        {
            TestHelpers.DeleteTestFiles();
        }
    }
}
