using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class StudentsRepository : BaseWithCodeRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
