namespace Grade_Scores.Model
{
    public class Student : IStudent
    {
        /// <summary>
        /// Create a new student
        /// </summary>
        public Student(string firstName, string lastName, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Score { get; }

        public string GetDetails()
        {
            return $"{LastName}, {FirstName}, {Score}";
        }
    }
}
