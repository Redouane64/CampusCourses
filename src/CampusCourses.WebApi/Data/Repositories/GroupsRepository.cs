using CampusCourses.Domain.Models;
using CampusCourses.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Data.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly DbSet<Group> groups;

        public GroupsRepository(DbSet<Group> groups)
        {
            this.groups = groups;
        }

        public async Task<Group> CreateAsync(Group entity, CancellationToken cancellationToken = default)
        {
            await groups.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<Group> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = await groups.FindAsync(new[] { id }, cancellationToken);

            if (entity is null)
            {
                return null;
            }

            groups.Remove(entity);

            return entity;
        }

        public Task<Group[]> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return groups.AsNoTracking().ToArrayAsync(cancellationToken);
        }

        public async Task<Group> UpdateAsync(string id, Group entity, CancellationToken cancellationToken = default)
        {
            var group = await groups.FindAsync(new[] { id }, cancellationToken);

            if (group is null)
            {
                return null;
            }

            group.Name = entity.Name;

            groups.Update(group);

            return entity;
        }
    }
}