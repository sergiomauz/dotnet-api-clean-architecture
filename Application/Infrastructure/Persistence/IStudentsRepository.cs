using Domain.Entities;


namespace Application.Infrastructure.Persistence
{
    public interface IStudentsRepository : IBaseWithCodeRepository<Student>
    {
        Task<List<Student>> SearchStudentsByTextFilterAsync(string textFilter, int currentPage, int pageSize);
        Task<int> TotalCountStudentsByTextFilterAsync(string textFilter);
    }
}
