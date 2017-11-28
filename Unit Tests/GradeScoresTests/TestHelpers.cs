using System;
using System.Collections.Generic;
using System.IO;

namespace GradeScoresTests
{
    internal class TestHelpers
    {
        /// <summary>
        /// Gets the Fully qualified string (Environment.CurrentDirectory\test.txt)
        /// </summary>
        internal static string TestFile => $@"{Path.GetTempPath()}test.txt";
        internal static string OutputFile => $@"{Path.GetTempPath()}test-Graded.txt";

        /// <summary>
        /// Creates an input file from a list of student strings.
        /// Pair this with a tear down of the generated file.
        /// </summary>
        /// <param name="students"></param>
        internal static string MockInputFileFromString(List<string> students)
        {
            using (StreamWriter output = new StreamWriter(TestFile))
            {
                foreach (var student in students)
                {
                    output.WriteLine(student);
                }
            }
            return TestFile;
        }

        internal static void DeleteTestFiles()
        {
            if (File.Exists(TestFile))
            {
                File.Delete(TestFile);
            }

            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }
        }
    }
}
