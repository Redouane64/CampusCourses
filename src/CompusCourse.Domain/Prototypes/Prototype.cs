using CompusCourse.Domain.Common;
using CompusCourse.Domain.Courses;

using System.Collections.Generic;

namespace CompusCourse.Domain.Prototypes
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
