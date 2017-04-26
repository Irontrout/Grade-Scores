using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grade_Scores
{
    internal class Student : IEquatable<Student>
    {
        /// <summary>
        /// Create an empty student.
        /// </summary>
        internal Student()
        { }

        /// <summary>
        /// Create a new student
        /// </summary>
        internal Student(string firstName, string lastName, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }

        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal int Score { get; set; }

        /// <summary>
        /// Get the data from how we would expect it to be entered in as.
        /// </summary>
        internal string StandardFullLine => $"{FirstName}, {LastName}, {Score}";
        
        /// <summary>
        /// Get the data from how we expect to output it as.
        /// </summary>
        internal string OrderedFullLine => $"{LastName}, {FirstName}, {Score}";

        ///
        /// IEquatable code
        /// 
        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && Score == other.Score;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Score;
                return hashCode;
            }
        }
    }
}
