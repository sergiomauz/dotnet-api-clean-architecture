using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public abstract class BaseWithIdRepository<T> : IBaseWithIdRepository<T>
        where T : BaseEntityWithId
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public BaseWithIdRepository(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            if (entity is BaseEntityWithId basicEntity)
            {
                basicEntity.CreatedAt = DateTime.UtcNow;
            }
            var entry = await _sqlServerDbContext.Set<T>().AddAsync(entity);
            await _sqlServerDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _sqlServerDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }
    }
}
