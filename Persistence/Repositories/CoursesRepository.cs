using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class CoursesRepository : BaseWithCodeRepository<Course>, ICoursesRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public CoursesRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }
    }
}
