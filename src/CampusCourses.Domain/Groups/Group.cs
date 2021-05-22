using System.Collections.Generic;
using CampusCourses.Domain.Common;
using CampusCourses.Domain.Prototypes;

namespace CampusCourses.Domain.Groups
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
