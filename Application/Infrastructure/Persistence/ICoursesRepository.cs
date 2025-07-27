using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface ICoursesRepository : IBaseWithCodeRepository<Course>
    {
        Task<List<Course>> GetCoursesByTeacherIdAsync(int teacherId, int currentPage, int pageSize);
        Task<int> TotalCoursesByTeacherIdAsync(int teacherId);

        Task<List<Course>> SearchCoursesByTextFilterAsync(string textFilter, int currentPage, int pageSize);
        Task<int> TotalCountCoursesByTextFilterAsync(string textFilter);
    }
}
