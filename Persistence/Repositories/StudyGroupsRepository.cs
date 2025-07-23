using Domain;
using Application.Infrastructure.Persistence;


namespace Persistence.Repositories
{
    public class StudyGroupsRepository : BaseWithCodeRepository<StudyGroup>, IStudyGroupsRepository
    {
        public StudyGroupsRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }
    }
}
