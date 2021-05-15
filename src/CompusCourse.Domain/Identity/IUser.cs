using CompusCourse.Domain.Courses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompusCourse.Domain.Identity
{
    public interface IUser
    {

        string Username { get; set; }

        string Email { get; set; }

        string Avatar { get; set; }

        ICollection<Course> Courses { get; set; }

        ICollection<Notification> Notifications { get; set; }

        ICollection<Review> Reviews { get; set; }

    }
}
