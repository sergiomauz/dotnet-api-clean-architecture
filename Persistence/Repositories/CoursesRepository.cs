using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class CoursesRepository : BaseWithCodeRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
