using Microsoft.EntityFrameworkCore.Storage;
using Application.Infrastructure.Persistence;


namespace Persistence
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly SqlServerDbContext _sqlServerDbContext;
        private IDbContextTransaction? _currentTransaction;

        public DatabaseTransaction(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public async Task BeginTransactionAsync(string transactionName)
        {
            _currentTransaction = await _sqlServerDbContext.Database.BeginTransactionAsync();
            //_currentTransaction
        }

        public async Task CommitTransactionAsync()
        {
            await _sqlServerDbContext.SaveChangesAsync();
            await _currentTransaction.CommitAsync();
            _currentTransaction?.Dispose();
            _currentTransaction = null;
        }

        public async Task RollbackTransactionAsync(string transactionName)
        {
            await _currentTransaction?.RollbackAsync();
            _currentTransaction?.Dispose();
            _currentTransaction = null;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _sqlServerDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _currentTransaction?.Dispose();
            _sqlServerDbContext?.Dispose();
        }
    }
}
