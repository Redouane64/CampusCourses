using CompusCourse.Domain.Common;

using System;

namespace CompusCourse.Domain.Courses
{
    /// <summary>
    /// Represents course review
    /// </summary>
    public sealed class Review : Entity
    {
        /// <summary>
        /// Review comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Review score
        /// </summary>
        public ReviewScore Score { get; set; }

        /// <summary>
        /// Review creation date
        /// </summary>
        public DateTimeOffset CreateAt { get; set; }
    }
}
