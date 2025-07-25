using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public abstract class BaseWithCodeRepository<T> : BaseWithIdRepository<T>, IBaseWithCodeRepository<T>
        where T : BaseEntityWithCode
    {
        public readonly SqlServerDbContext SqlServerDbContext;

        public BaseWithCodeRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            SqlServerDbContext = sqlServerDbContext;
        }

        public virtual async Task<T?> GetByCodeAsync(string code)
        {
            var entity = await SqlServerDbContext.Set<T>().FirstOrDefaultAsync(e => e.Code.Equals(code));

            return entity;
        }
    }
}
