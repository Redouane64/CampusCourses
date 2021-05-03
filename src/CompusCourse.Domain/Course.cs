using System;
using System.Collections.Generic;

namespace CompusCourse.Domain
{
    /// <summary>
    /// Represent course entity
    /// </summary>
    public sealed class Course : AggregateRoot
    {
        /// <summary>
        /// Initialize a Course instance.
        /// </summary>
        /// <param name="group">Course group name</param>
        /// <param name="name">Course name</param>
        public Course(string group, string name)
        {
            Group = new Group(group);
            Name = name;
        }
        
        /// <summary>
        /// Initialize a Course instance with existing reviews collection.
        /// </summary>
        /// <param name="group">Course group name</param>
        /// <param name="name">Course name</param>
        /// <param name="reviews">Course reviews</param>
        public Course(string group, string name, IReadOnlyCollection<Review> reviews)
            : this(group, name)
        {
            if (string.IsNullOrEmpty(group))
            {
                throw new ArgumentException($"'{nameof(group)}' cannot be null or empty.", nameof(group));
            }

            if (reviews is null)
            {
                throw new ArgumentNullException(nameof(reviews));
            }

            Reviews = new List<Review>(reviews);
            Name = name;
        }

        /// <summary>
        /// Course name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Course group
        /// </summary>
        public Group Group { get; }

        /// <summary>
        /// Course reviews
        /// </summary>
        public ICollection<Review> Reviews { get; }

        /// <summary>
        /// Add course review
        /// </summary>
        /// <param name="username">Reviewer user name</param>
        /// <param name="comment">Review comment</param>
        /// <param name="score">Review score</param>
        public void AddReview(string username, string comment, ReviewScore score)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(comment))
            {
                throw new ArgumentException($"'{nameof(comment)}' cannot be null or empty.", nameof(comment));
            }

            var review = new Review(username, Name, score, comment);

            Reviews.Add(review);
        }
    }
}
