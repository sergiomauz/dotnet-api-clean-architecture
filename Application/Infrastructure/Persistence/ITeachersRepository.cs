using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface ITeachersRepository : IBaseWithCodeRepository<Teacher>
    {
        Task<List<Teacher>> SearchTeachersByTextFilterAsync(string textFilter, int currentPage, int pageSize);
        Task<int> TotalCountTeachersByTextFilterAsync(string textFilter);
    }
}
