using CampusCourses.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusCourses.Domain.Courses
{
    public interface ICoursesRepository : IRepository<Course>
    {
    }

    public interface IGroupsRepository : IRepository<Group>
    {
    }

    public interface IPrototypesRepository : IRepository<Prototype>
    {
    }

    public interface INotificationRepository : IRepository<Notification>
    {
    }
}
