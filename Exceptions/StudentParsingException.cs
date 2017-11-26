using System;
using Grade_Scores.Model;

namespace Grade_Scores
{
    class StudentParsingException : Exception
    {
        public StudentParsingException()
        {
        }

        public StudentParsingException(string message)
            : base(message)
        {
        }

        public StudentParsingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
