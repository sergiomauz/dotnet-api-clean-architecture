using Microsoft.EntityFrameworkCore;
using Domain.Entities;
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

        public async Task<List<Student>> SearchStudentsByTextFilterAsync(string textFilter, int currentPage, int pageSize)
        {
            var teachers = await (from st in _sqlServerDbContext.Set<Student>()
                                  where st.Code.Contains(textFilter) || st.Firstname.Contains(textFilter)
                                         || st.Lastname.Contains(textFilter)
                                  orderby st.CreatedAt descending
                                  select new Student
                                  {
                                      Id = st.Id,
                                      Code = st.Code,
                                      Firstname = st.Firstname,
                                      Lastname = st.Lastname,
                                      BirthDate = st.BirthDate,
                                      CreatedAt = st.CreatedAt,
                                      ModifiedAt = st.ModifiedAt
                                  })
                                .Skip(Convert.ToInt32(pageSize) * (Convert.ToInt32(currentPage) - 1))
                                .Take(Convert.ToInt32(pageSize))
                                .ToListAsync();

            return teachers;
        }

        public async Task<int> TotalCountStudentsByTextFilterAsync(string textFilter)
        {
            var count = await (from st in _sqlServerDbContext.Set<Student>()
                               where st.Code.Contains(textFilter) || st.Firstname.Contains(textFilter)
                                      || st.Lastname.Contains(textFilter)
                               select st)
                               .CountAsync();

            return count;
        }
    }
}
