using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CampusCourses.Domain.Models;
using CampusCourses.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CampusCourses.WebApi.Data.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly DbSet<Group> groups;

        public GroupsRepository(DbSet<Group> groups)
        {
            this.groups = groups;
        }

        public Task<Group> CreateAsync(Group entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Group> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Group> UpdateAsync(string id, Group entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}