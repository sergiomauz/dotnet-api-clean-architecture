namespace Domain
{
    public class Teacher : BasicEntity
    {
        #region ====== RELATIONSHIPS: ONE TO MANY - HAS MANY ======
        public IEnumerable<School> Schools { get; set; }
        #endregion

        public string Code { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
