using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Identity.Commands
{
    public class LoginCommand
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }

        public string Password { get; }
    }
}
