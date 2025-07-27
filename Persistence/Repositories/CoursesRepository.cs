using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Course>> GetCoursesByTeacherIdAsync(int teacherId, int currentPage, int pageSize)
        {
            var courses = await (from en in _sqlServerDbContext.Set<Enrollment>()
                                 join co in _sqlServerDbContext.Set<Course>() on en.CourseId equals co.Id into leftJoinCO
                                 from enco in leftJoinCO.DefaultIfEmpty()
                                 where enco.TeacherId == teacherId
                                 group new { en, enco } by new
                                 {
                                     enco.Id,
                                     enco.Code,
                                     enco.Name,
                                     enco.CreatedAt
                                 } into g
                                 orderby g.Key.CreatedAt descending
                                 select new Course
                                 {
                                     Id = g.Key.Id,
                                     Code = g.Key.Code,
                                     Name = g.Key.Name,
                                     NotMappedStudents = g.Count()
                                 })
                                .Skip(Convert.ToInt32(pageSize) * (Convert.ToInt32(currentPage) - 1))
                                .Take(Convert.ToInt32(pageSize))
                                .ToListAsync();

            return courses;
        }

        public async Task<int> TotalCoursesByTeacherIdAsync(int teacherId)
        {
            var count = await (from en in _sqlServerDbContext.Set<Course>()
                               where en.TeacherId == teacherId
                               select en)
                              .CountAsync();

            return count;
        }

        public async Task<List<Course>> SearchCoursesByTextFilterAsync(string textFilter, int currentPage, int pageSize)
        {
            var courses = await (from co in _sqlServerDbContext.Set<Course>()
                                 where co.Code.Contains(textFilter) || co.Name.Contains(textFilter)
                                        || co.Description.Contains(textFilter)
                                 orderby co.CreatedAt descending
                                 select new Course
                                 {
                                     Id = co.Id,
                                     Code = co.Code,
                                     Name = co.Name,
                                     Description = co.Description,
                                     CreatedAt = co.CreatedAt,
                                     ModifiedAt = co.ModifiedAt
                                 })
                                .Skip(Convert.ToInt32(pageSize) * (Convert.ToInt32(currentPage) - 1))
                                .Take(Convert.ToInt32(pageSize))
                                .ToListAsync();

            return courses;
        }

        public async Task<int> TotalCountCoursesByTextFilterAsync(string textFilter)
        {
            var count = await (from co in _sqlServerDbContext.Set<Course>()
                               where co.Code.Contains(textFilter) || co.Name.Contains(textFilter)
                                      || co.Description.Contains(textFilter)
                               select co)
                               .CountAsync();

            return count;
        }
    }
}
