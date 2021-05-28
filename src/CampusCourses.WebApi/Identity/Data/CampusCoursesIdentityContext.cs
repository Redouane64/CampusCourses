using CampusCourses.WebApi.Identity.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusCourses.WebApi.Identity.Data
{
    public class CampusCoursesIdentityContext : IdentityDbContext<CampusCoursesUser>
    {
        public CampusCoursesIdentityContext(DbContextOptions<CampusCoursesIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole(Constants.Roles.Administrator));
        }
    }
}
