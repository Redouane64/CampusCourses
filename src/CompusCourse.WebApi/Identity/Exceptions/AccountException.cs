using CompusCourse.WebApi.Common.Exceptions;
using CompusCourse.WebApi.Identity.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Identity.Exceptions
{
    public class AccountException : CampusCoursesException
    {
        public AccountException(string code, int status, string[] errors) 
            : base(code, status)
        {
            Errors = errors;
        }

        public string[] Errors { get; }
    }
}
