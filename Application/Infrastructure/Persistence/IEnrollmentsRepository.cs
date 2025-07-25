using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IEnrollmentsRepository : IBaseWithIdRepository<Enrollment>
    {
        Task<Enrollment?> GetEnrollmentsByStudentIdAsync(int courseId, int studentId);
    }
}
