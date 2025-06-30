using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class SchoolsRepository : BaseWithCodeRepository<School>, ISchoolsRepository
    {
        public SchoolsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
