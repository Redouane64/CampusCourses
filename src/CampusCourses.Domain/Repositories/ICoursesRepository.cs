using CampusCourses.Domain.Common;
using CampusCourses.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusCourses.Domain.Repositories
{
    public interface ICoursesRepository : IRepository<Course>
    {
    }
}
