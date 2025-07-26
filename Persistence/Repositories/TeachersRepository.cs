using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class TeachersRepository : BaseWithCodeRepository<Teacher>, ITeachersRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public TeachersRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }
    }
}
