using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class TeachersRepository : BaseWithCodeRepository<Teacher>, ITeachersRepository
    {
        public TeachersRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
