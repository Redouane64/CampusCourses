using CompusCourse.Domain.Common;
using CompusCourse.Domain.Courses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompusCourse.Domain.Identity
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
