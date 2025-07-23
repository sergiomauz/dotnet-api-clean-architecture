using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IEnrollmentsRepository : IBaseWithIdRepository<Enrollment>
    {
        Task<Enrollment?> GetEnrollmentByStudentIdAsync(int studyGroupId, int studentId);
    }
}
