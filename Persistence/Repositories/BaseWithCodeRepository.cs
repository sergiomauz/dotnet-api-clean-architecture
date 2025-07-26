using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public abstract class BaseWithCodeRepository<T> : BaseWithIdRepository<T>, IBaseWithCodeRepository<T>
        where T : BaseEntityWithCode
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public BaseWithCodeRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public virtual async Task<T?> GetByCodeAsync(string code)
        {
            var entity = await _sqlServerDbContext.Set<T>().FirstOrDefaultAsync(e => e.Code.Equals(code));

            return entity;
        }
    }
}
