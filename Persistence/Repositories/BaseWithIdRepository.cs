using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Bases;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public abstract class BaseWithIdRepository<T> : IBaseWithIdRepository<T> where T : BaseEntityWithId
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public BaseWithIdRepository(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public async Task<DbConnection> EnsureConnectionOpenAsync(DbContext dbContext)
        {
            var connection = dbContext.Database.GetDbConnection();
            if (dbContext.Database.GetDbConnection().State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            return connection;
        }

        public string ConvertToSQL(object? value)
        {
            if (value == null)
            {
                return "NULL";
            }

            if (value is string s)
            {
                return $"'{s.Replace("'", "''")}'";
            }

            if (value is DateTime dt)
            {
                return $"'{dt:yyyy-MM-dd HH:mm:ss}'";
            }

            if (value is bool b)
            {
                return b ? "1" : "0";
            }

            if (value is IEnumerable<object> enumerable && value is not string)
            {
                var items = enumerable.Select(ConvertToSQL);
                return $"({string.Join(", ", items)})";
            }

            return value.ToString() ?? "NULL";
        }

        public virtual async Task<T?> CreateAsync(T entity)
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

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            var existingEntity = await _sqlServerDbContext.Set<T>().SingleOrDefaultAsync(t => t.Id == entity.Id);
            if (existingEntity == null)
                return null;

            if (entity is BaseEntityWithId tracked)
            {
                tracked.ModifiedAt = DateTime.UtcNow;
            }
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
