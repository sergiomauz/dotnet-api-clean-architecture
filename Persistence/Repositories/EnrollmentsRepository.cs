using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class EnrollmentsRepository : BaseWithIdRepository<Enrollment>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
