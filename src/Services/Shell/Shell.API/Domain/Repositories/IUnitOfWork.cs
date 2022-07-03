using System.Threading.Tasks;

namespace Shell.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IPageRepository PageRepository { get; }
        IRowRepository RowRepository { get; }
        Task BeginTransactionAsync();
        Task RollbackChangesAsync();
        Task CommitChangesAsync();
    }
}
