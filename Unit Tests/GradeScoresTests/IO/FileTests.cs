using System.Collections.Generic;
using System.IO;
using Grade_Scores;
using Grade_Scores.ReaderWriters;
using NUnit.Framework;

namespace GradeScoresTests
{
    [TestFixture]
    class DataCSVTests
    {
        // This could be a setup function, but having a specified input file means we can test more.
        private StandardStudentReader GenerateStudentReader(string inputFile = null)
        {
            // Set the test help file if no inputfile was given.
            var file = inputFile ?? TestHelpers.TestFile;

            var students = new List<string>
            {
                "Aaron, Aaronson, 10",
                "Daniel, Danielson, 20",
                "Johnathan, Johannson, 30",
                "Borris, Borrisson, 40"
            };

            // Generate mock file
            TestHelpers.MockInputFileFromString(students);

            // Generate StudentList from File
            return new StandardStudentReader(file);
        }


        [TestCase(@"C:\test\output.txt", @"C:\test\output_Graded.txt")]
        [TestCase("output.txt", "output_Graded.txt")]
        [TestCase("output", "output_Graded.txt")]
        public void WriteFileAmbiguityTest(string inputFilePath, string outputFilePath)
        {
            var studentReader = GenerateStudentReader(inputFilePath);
            Assert.That(studentReader.WriteFilePath.Equals(outputFilePath));
        }

        [TearDown]
        public void TearDown()
        {
            TestHelpers.DeleteTestFiles();
        }
    }
}
