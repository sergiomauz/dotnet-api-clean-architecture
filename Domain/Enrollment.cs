namespace Domain
{
    public class Enrollment : BaseEntityWithId
    {
        #region ====== RELATIONSHIPS: BELONGS TO ======
        public int? StudyGroupId { get; set; }
        public StudyGroup? StudyGroup { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        #endregion
    }
}
