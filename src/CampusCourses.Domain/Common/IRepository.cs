using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CampusCourses.Domain.Common
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(string id, TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}
