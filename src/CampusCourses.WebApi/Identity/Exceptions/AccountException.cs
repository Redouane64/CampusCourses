using CampusCourses.WebApi.Common.Exceptions;

namespace CampusCourses.WebApi.Identity.Exceptions
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
