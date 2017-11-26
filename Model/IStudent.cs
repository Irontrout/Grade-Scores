using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Scores.Model
{
    public interface IStudent
    {
        string FirstName { get; }
        string LastName { get; }
        int Score { get; }

        string GetDetails();
    }
}
