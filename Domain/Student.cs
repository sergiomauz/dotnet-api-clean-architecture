namespace Domain
{
    public class Student : BasicEntity
    {
        #region ====== RELATIONSHIPS: ONE TO MANY - HAS MANY ======
        public IEnumerable<Enrollment> Enrollments { get; set; }
        #endregion

        public string Code { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
