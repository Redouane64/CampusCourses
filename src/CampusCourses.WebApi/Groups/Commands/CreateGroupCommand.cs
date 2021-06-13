using CampusCourses.WebApi.Data;
using CampusCourses.WebApi.Groups.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Groups.Commands
{
    public class CreateGroupCommand : IRequest
    {
        public CreateGroupCommand(CreateGroup model)
        {
            Model = model;
        }

        public CreateGroup Model { get; }
    }

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand>
    {
        private readonly ICampusCoursesUnitOfWork unitOfWork;

        public CreateGroupCommandHandler(ICampusCoursesUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
