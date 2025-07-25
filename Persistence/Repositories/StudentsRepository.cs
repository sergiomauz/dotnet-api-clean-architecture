using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class StudentsRepository : BaseWithCodeRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }

        public async Task<List<Enrollment>> GetCoursesByStudentId(int studentId, int currentPage, int pageSize)
        {
            var enrollments = await (from co in SqlServerDbContext.Set<Course>()
                                     join en in SqlServerDbContext.Set<Enrollment>() on co.Id equals en.CourseId
                                     join te in SqlServerDbContext.Set<Teacher>() on co.TeacherId equals te.Id
                                     where en.StudentId == studentId
                                     orderby en.CreatedAt descending
                                     select new Enrollment
                                     {
                                         Course = new Course
                                         {
                                             Code = co.Code,
                                             Name = co.Name,
                                             Teacher = new Teacher
                                             {
                                                 Firstname = te.Firstname,
                                                 Lastname = te.Lastname
                                             }
                                         },
                                         CreatedAt = en.CreatedAt
                                     })
                                   .Skip(Convert.ToInt32(pageSize) * (Convert.ToInt32(currentPage) - 1))
                                   .Take(Convert.ToInt32(pageSize))
                                   .ToListAsync();

            return enrollments;
        }

        public async Task<int> TotalCountCoursesByStudentIdAsync(int studentId)
        {
            var count = await (from en in SqlServerDbContext.Set<Enrollment>()
                               where en.StudentId == studentId
                               select en)
                               .CountAsync();

            return count;
        }
    }
}
