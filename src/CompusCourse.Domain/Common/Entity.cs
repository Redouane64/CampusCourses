namespace CompusCourse.Domain.Common
{
    /// <summary>
    /// Represents base domain entity
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Entity primary key
        /// </summary>
        public virtual string Id { get; protected set; }
    }
}
