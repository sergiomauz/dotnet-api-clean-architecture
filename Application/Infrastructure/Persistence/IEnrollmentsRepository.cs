using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IEnrollmentsRepository : IBaseWithIdRepository<Enrollment>
    {
        Task<Enrollment?> GetEnrollmentsByStudentIdAsync(int courseId, int studentId);
        Task<List<Enrollment>> GetCoursesByStudentId(int studentId, int currentPage, int pageSize);
        Task<int> TotalCountCoursesByStudentIdAsync(int studentId);
    }
}
