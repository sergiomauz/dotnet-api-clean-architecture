using Domain.Entities.Bases;


namespace Domain.Entities
{
    public class Enrollment : BaseEntityWithId
    {
        #region ====== RELATIONSHIPS: BELONGS TO ======
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        #endregion
    }
}
