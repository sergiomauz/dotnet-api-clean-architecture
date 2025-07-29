using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Infrastructure.Persistence;
using Persistence.Repositories.Bases;


namespace Persistence.Repositories
{
    public class TeachersRepository : BaseWithCodeRepository<Teacher>, ITeachersRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public TeachersRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public async Task<List<Teacher>> SearchTeachersByTextFilterAsync(string textFilter, int currentPage, int pageSize)
        {
            var teachers = await (from te in _sqlServerDbContext.Set<Teacher>()
                                  where te.Code.Contains(textFilter) || te.Firstname.Contains(textFilter)
                                         || te.Lastname.Contains(textFilter)
                                  orderby te.CreatedAt descending
                                  select new Teacher
                                  {
                                      Id = te.Id,
                                      Code = te.Code,
                                      Firstname = te.Firstname,
                                      Lastname = te.Lastname,
                                      CreatedAt = te.CreatedAt,
                                      ModifiedAt = te.ModifiedAt
                                  })
                                   .Skip(Convert.ToInt32(pageSize) * (Convert.ToInt32(currentPage) - 1))
                                   .Take(Convert.ToInt32(pageSize))
                                   .ToListAsync();

            return teachers;
        }

        public async Task<int> TotalCountTeachersByTextFilterAsync(string textFilter)
        {
            var count = await (from te in _sqlServerDbContext.Set<Teacher>()
                               where te.Code.Contains(textFilter) || te.Firstname.Contains(textFilter)
                                      || te.Lastname.Contains(textFilter)
                               select te)
                               .CountAsync();

            return count;
        }
    }
}
