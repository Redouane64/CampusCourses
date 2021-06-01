using System;
using System.Threading;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Data
{
    public interface IDataContext : IDisposable, IAsyncDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}