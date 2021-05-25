using CampusCourses.Domain.Common;

using System.Collections.Generic;

namespace CampusCourses.Domain.Courses
{
    /// <summary>
    /// Represents course prototype
    /// </summary>
    public class Prototype : Entity
    {
        /// <summary>
        /// Prototype name
        /// </summary>
        public string Name { get; set; }

        public string Credit { get; set; }

        public ICollection<Language> Languages { get; set; }

        public string Requirements { get; set; }

        public string Annotation { get; set; }

        public string Materials { get; set; }

        public string Literature { get; set; }

        /// <summary>
        /// Prototype courses
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}
