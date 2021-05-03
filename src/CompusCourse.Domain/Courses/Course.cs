using CompusCourse.Domain.Common;

using System.Collections.Generic;

namespace CompusCourse.Domain.Courses
{
    /// <summary>
    /// Represents course entity
    /// </summary>
    public sealed class Course : Entity
    {
        /// <summary>
        /// Course name
        /// </summary>
        public string Name { get; set;  }

        /// <summary>
        /// Course reviews
        /// </summary>
        public ICollection<Review> Reviews { get; set; }
    }
}
