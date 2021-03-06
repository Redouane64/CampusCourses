using CampusCourses.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace CampusCourses.WebApi.Identity.Entities
{
    public class CampusCoursesUser : IdentityUser, IUser
    {
        public string Avatar { get; set; }
    }
}
