using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Common.Exceptions
{
    public class CampusCoursesException : Exception
    {
        public CampusCoursesException(string code, int status)
        {
            Code = code;
            Status = status;
        }

        public string Code { get; }

        public int Status { get; set; }
    }
}
