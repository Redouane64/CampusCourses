using CompusCourse.Domain.Common;
using CompusCourse.Domain.Prototypes;

using System.Collections.Generic;

namespace CompusCourse.Domain.Groups
{
    /// <summary>
    /// Represents course group entity
    /// </summary>
    public sealed class Group : AggregateRoot
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
