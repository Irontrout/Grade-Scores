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
        internal static string TestFile => $@"{Environment.CurrentDirectory}\test.txt";
        internal static string OutputFile => $@"{Environment.CurrentDirectory}\test-Graded.txt";

        /// <summary>
        /// Creates an input file from a list of student strings.
        /// Pair this with a tear down of the generated file.
        /// </summary>
        /// <param name="students"></param>
        internal static void MockInputFileFromString(List<string> students)
        {
            using (StreamWriter output = new StreamWriter(TestFile))
            {
                foreach (var student in students)
                {
                    output.WriteLine(student);
                }
            }
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
