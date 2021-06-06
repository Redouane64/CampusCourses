using System.Collections.Generic;

using CampusCourses.Domain.Common;

namespace CampusCourses.Domain.Models
{
    /// <summary>
    /// Represents course group entity
    /// </summary>
    public sealed class Group : Entity, IAggregateRoot
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Group prototypes
        /// </summary>
        public ICollection<Prototype> Prototypes { get; set; }

    }
}
