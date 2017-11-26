using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Scores.Logging
{
    class DebugLog : Logger
    {
        public override void Write(string message, LogCode code)
        {
            Console.WriteLine($"[{code}] - {message}");
        }
    }
}
