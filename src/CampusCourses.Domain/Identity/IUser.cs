using CampusCourses.Domain.Common;

namespace CampusCourses.Domain.Identity
{
    /// <summary>
    /// Represent a common user entity contract.
    /// </summary>
    public interface IUser : IAggregateRoot
    {
        string Email { get; set; }
        string Avatar { get; set; }
    }
}
