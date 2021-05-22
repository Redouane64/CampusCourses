namespace CampusCourses.Domain.Common
{
    public abstract class Entity : IEntity
    {
        public virtual string Id { get; protected set; }
    }
}
