using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class StudentsRepository : BaseWithCodeRepository<Student>, IStudentsRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public StudentsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }
    }
}
