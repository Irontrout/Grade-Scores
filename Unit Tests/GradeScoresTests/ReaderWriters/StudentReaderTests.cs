using System;
using System.Collections.Generic;
using System.Linq;
using Grade_Scores;
using Grade_Scores.Model;
using NUnit.Framework;
using Grade_Scores.ReaderWriters;
using NUnit.Framework.Internal;

namespace GradeScoresTests.ReaderWriters
{
    [TestFixture]
    public class StudentReaderTests
    {
        [TestCase("Abigail", "Aaronson", 20, false)] // Same Score, Earlier both names
        [TestCase("Zander", "Zandinson", 20, true)] // Same Score, later both names
        [TestCase("Gary", "Aaronson", 20, false)] // Same Score + first name, earlier last name
        [TestCase("Gary", "Zandinson", 20, true)] // Same Score + First name, later last name
        [TestCase("Abigail", "Garrison", 20, false)] // Same Score + Last name, earlier first name
        [TestCase("Zander", "Garrison", 20, true)] // Same Score + Last name, later first name
        [TestCase("Gary", "Garrison", 25, false)] // Same First name + last name, higher score
        [TestCase("Gary", "Garrison", 15, true)] // Same First name + last name, lower score
        public void OrderedOutputTest(string firstName, string lastName, int score, bool isKeyFirstOnList)
        {
            // Assign
            var reader = new StandardStudentReader();
            
            var baseStudent = new Student("Gary", "Garrison", 20);
            var newStudent = new Student(firstName, lastName, score);

            reader.Students = new List<IStudent>() {baseStudent, newStudent};

            // Act
            reader.OrderStudents();

            // Assert
            // Assert whether the key student should be the first student or not.
            Assert.AreEqual(reader.Students.First().Equals(baseStudent), isKeyFirstOnList);
        }
        
        [TestCase("Gary, Garrison")] // Too Few
        [TestCase("Gary, Garrison, 15, EXTRAWORD")] // Too Many
        public void LogFailedStudents(string inputStudent)
        {
            // Assign / Act
            var studentReader =
                new StandardStudentReader(TestHelpers.MockInputFileFromString(new List<string>() { inputStudent }));

            // Assert
            Assert.That(()=> studentReader.Read(), Throws.TypeOf<StudentParsingException>());
        }

        [TearDown]
        public void TearDown()
        {
            TestHelpers.DeleteTestFiles();
        }
    }
}
