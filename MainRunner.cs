using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grade_Scores.Logging;
using Grade_Scores.Model;
using Grade_Scores.ReaderWriters;

namespace Grade_Scores
{
    public static class MainRunner
    {
        public static void Run(string filepath, ILog logger)
        {
            var studentReader = new StandardStudentReader(filepath);

            try
            {
                studentReader.Read();
            }
            catch (IOException e)
            {
                logger.Write($"Error accessing scores file.\n{e}", LogCode.ERR);
                return;
            }
            catch (StudentParsingException e)
            {
                logger.Write("Error while reading student list. Please check data structure before continuing", LogCode.ERR);
                return;
            }

            studentReader.OrderStudents();

            try
            {
                studentReader.Write();
            }
            catch (Exception e)
            {
                logger.Write($"Error writing to {Path.GetFileName(filepath)}.\n{e}", LogCode.ERR);
            }
        }
    }
}
