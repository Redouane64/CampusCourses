using System;

namespace CompusCourse.Domain
{
    public sealed class Review : Entity
    {

        public Review(string username, string course, ReviewScore score, string comment)
        {
            Username = username;
            Course = course;
            Score = score;

            Date = DateTimeOffset.Now;
            Id = Guid.NewGuid().ToString();
            Comment = comment;
        }

        public string Username { get; }

        public string Course { get; }

        public string Comment { get; }

        public ReviewScore Score { get; }

        public DateTimeOffset Date { get; }

    }
}
