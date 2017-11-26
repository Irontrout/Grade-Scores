using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Scores.Logging
{
    public interface ILog
    {
        void Write(string message);
        void Write(string message, LogCode code);
    }
}
