using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IStudentsRepository : IBaseWithCodeRepository<Student>
    {
        Task<List<Enrollment>> GetCoursesByStudentId(int studentId, int currentPage, int pageSize);
        Task<int> TotalCountCoursesByStudentIdAsync(int studentId);
    }
}
