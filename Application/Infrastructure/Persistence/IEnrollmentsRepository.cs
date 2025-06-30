using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IEnrollmentsRepository : IBaseWithIdRepository<Enrollment>
    {
        Task<Enrollment?> GetEnrollmentByStudentIdAsync(int schoolId, int studentId);
    }
}
