using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusCourses.WebApi.Common.Constants;
using CampusCourses.WebApi.Common.ViewModels;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace CampusCourses.WebApi.Infrastructure
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        public JsonExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            ErrorViewModel error;
            if (_env.IsDevelopment())
            {
                error = new ErrorViewModel(CampusCoursesErrorCodes.InternalServerError, 500, new[] { context.Exception.Message }, context.Exception.StackTrace);
            }
            else
            {
                error = new ErrorViewModel(CampusCoursesErrorCodes.InternalServerError, 500);
            }

            context.Result = new ObjectResult(error) { StatusCode = 500 };
        }
    }
}
