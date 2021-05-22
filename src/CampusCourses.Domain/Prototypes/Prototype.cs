using System.Collections.Generic;
using CampusCourses.Domain.Common;
using CampusCourses.Domain.Courses;

namespace CampusCourses.Domain.Prototypes
{
    /// <summary>
    /// Represents course prototype
    /// </summary>
    public sealed class Prototype : Entity
    {
        /// <summary>
        /// Prototype name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Prototype courses
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}
