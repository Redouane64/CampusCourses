using CompusCourse.WebApi.Identity.Models;
using CompusCourse.WebApi.Identity.Services;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Identity.Commands
{
    public class RegisterCommand : IRequest<Token>
    {

        public RegisterCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }

        public string Password { get; }
    }

    public class RegisterHandler : IRequestHandler<RegisterCommand, Token>
    {
        public Task<Token> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
