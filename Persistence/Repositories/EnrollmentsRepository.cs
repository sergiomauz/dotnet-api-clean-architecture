using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class EnrollmentsRepository : BaseWithIdRepository<Enrollment>, IEnrollmentsRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public EnrollmentsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public virtual async Task<Enrollment?> GetEnrollmentByStudentIdAsync(int schoolId, int studentId)
        {
            var entity = await _sqlServerDbContext.Set<Enrollment>().SingleOrDefaultAsync(t => t.SchoolId == schoolId && t.StudentId == studentId);

            return entity;
        }
    }
}
