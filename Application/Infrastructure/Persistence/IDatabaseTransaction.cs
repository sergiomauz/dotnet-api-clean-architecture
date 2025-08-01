namespace Application.Infrastructure.Persistence
{
    public interface IDatabaseTransaction : IDisposable
    {
        Task BeginTransactionAsync(string transactionName);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync(string transactionName);
        Task<int> SaveChangesAsync();
    }
}
