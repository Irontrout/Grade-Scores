using System.Collections.Generic;
using System.IO;
using Grade_Scores;
using NUnit.Framework;

namespace GradeScoresTests
{
    [TestFixture]
    class DataCSVTests
    {
        private DataCSV data;
        private StudentList studentList;

        [SetUp]
        public void Setup()
        {
            var students = new List<string>
            {
                "Aaron, Aaronson, 10",
                "Daniel, Danielson, 20",
                "Johnathan, Johannson, 30",
                "Vlad, The Impala, 40"
            };

            // Generate mock file
            TestHelpers.MockInputFileFromString(students);

            // Generate StudentList from File
            studentList = new StudentList(TestHelpers.TestFile);

            // Generate DataCSV from file
            data = new DataCSV(TestHelpers.TestFile);
        }

        [Test]
        public void FileExistsTest()
        {
            // Test the fully qualified name
            Assert.IsNotEmpty(DataCSV.GetFile(TestHelpers.TestFile));
            // Test the Relative name
            Assert.IsNotEmpty(DataCSV.GetFile("test.txt"));
            // Make sure that the file exists in our comparison as well.
            Assert.That(data.FileExists);
        }


        [Test]
        public void OutputFileIsGeneratedTest()
        {
            // Act
            data.WriteOutputCSV(studentList);

            // Assert
            Assert.That(File.Exists(TestHelpers.OutputFile));
        }

        [TearDown]
        public void TearDown()
        {
            TestHelpers.DeleteTestFiles();
        }
    }
}
