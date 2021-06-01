using CampusCourses.Domain.Courses;

namespace CampusCourses.WebApi.Data
{
    public interface ICampusCoursesUnitOfWork
    {
        ICoursesRepository Courses { get; }
        IGroupsRepository Groups { get; }
        IPrototypesRepository Prototypes { get; }
        INotificationRepository Notifications { get; }
    }
}