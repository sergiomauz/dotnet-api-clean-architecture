namespace Domain
{
    public class School : BasicEntity
    {
        #region ====== RELATIONSHIPS: ONE TO MANY - HAS MANY ======
        public IEnumerable<Enrollment> Enrollments { get; set; }
        #endregion

        #region ====== RELATIONSHIPS: BELONGS TO ======
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        #endregion

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
