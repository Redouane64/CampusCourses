using System.Collections.Generic;

using CampusCourses.Domain.Common;

namespace CampusCourses.Domain.Models
{
    /// <summary>
    /// Represents course entity
    /// </summary>
    public sealed class Course : Entity
    {
        /// <summary>
        /// Prototype name
        /// </summary>
        public string Name { get; set; }

        public string Credit { get; set; }

        public Language Language { get; set; }

        public string Requirements { get; set; }

        public string Annotation { get; set; }

        public string Materials { get; set; }

        public string Literature { get; set; }

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
