namespace Domain
{
    public class Enrollment : BasicEntity
    {
        #region ====== RELATIONSHIPS: BELONGS TO ======
        public int? SchoolId { get; set; }
        public School? School { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        #endregion
    }
}
