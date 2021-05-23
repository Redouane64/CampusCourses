
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Common.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string code, int status)
        {
            Code = code;
            Status = status;
        }

        public ErrorViewModel(string code, int status, string[] details)
            : this(code, status)
        {
            Details = details;
        }

        public ErrorViewModel(string code, int status, string[] details, string stacktrace)
            : this(code, status, details)
        {
            StackTrace = stacktrace;
        }

        public int Status { get; }

        public string Code { get; }

        public string[] Details { get; set; }

        public string StackTrace { get; set; }
    }
}
