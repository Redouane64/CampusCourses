namespace CompusCourse.Domain.Common
{
    /// <summary>
    /// Represents base domain entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity primary key
        /// </summary>
        string Id { get; }
    }
}
