using CampusCourses.Domain.Repositories;

namespace CampusCourses.WebApi.Data
{
    public class CampusCoursesUnitOfWork : UnitOfWork, ICampusCoursesUnitOfWork
    {
        public CampusCoursesUnitOfWork(IDataContext dataContext) 
            : base(dataContext)
        {
        }

        public ICoursesRepository Courses => throw new System.NotImplementedException();

        public IGroupsRepository Groups => throw new System.NotImplementedException();

        public IPrototypesRepository Prototypes => throw new System.NotImplementedException();

        public INotificationRepository Notifications => throw new System.NotImplementedException();
    }
}