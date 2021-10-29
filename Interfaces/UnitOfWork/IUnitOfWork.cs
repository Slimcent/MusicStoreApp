using Entities.Models;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        int Commit();
    }
}
