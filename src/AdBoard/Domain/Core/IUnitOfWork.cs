using System.Threading;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}