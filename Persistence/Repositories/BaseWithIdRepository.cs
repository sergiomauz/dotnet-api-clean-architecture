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
            if (entity is BaseEntityWithId tracked)
            {
                tracked.CreatedAt = DateTime.UtcNow;
            }
            var entry = await _sqlServerDbContext.Set<T>().AddAsync(entity);
            await _sqlServerDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var entity = await _sqlServerDbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            _sqlServerDbContext.Set<T>().Remove(entity);
            var affectedRows = await _sqlServerDbContext.SaveChangesAsync();

            return affectedRows;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var existingEntity = await _sqlServerDbContext.Set<T>().SingleOrDefaultAsync(t => t.Id == entity.Id);
            if (existingEntity == null)
                return null;

            _sqlServerDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _sqlServerDbContext.SaveChangesAsync();

            return existingEntity;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _sqlServerDbContext.Set<T>().SingleOrDefaultAsync(t => t.Id == id);

            return entity;
        }
    }
}
