using System;

namespace CompusCourse.Domain
{
    /// <summary>
    /// Represents course group entity
    /// </summary>
    public sealed class Group : Entity
    {
        public Group(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Name { get; }
    }
}
