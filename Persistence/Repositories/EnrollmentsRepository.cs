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

        public async Task<Enrollment?> GetEnrollmentsByStudentIdAsync(int courseId, int studentId)
        {
            var entity = await _sqlServerDbContext.Set<Enrollment>().SingleOrDefaultAsync(t => t.CourseId == courseId && t.StudentId == studentId);

            return entity;
        }
    }
}
