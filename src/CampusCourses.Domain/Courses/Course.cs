using System.Collections.Generic;
using CampusCourses.Domain.Common;

namespace CampusCourses.Domain.Courses
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

        /// <summary>
        /// Course notifications
        /// </summary>
        public ICollection<Notification> Notifications { get; set; }
    }
}
