namespace Domain
{
    public class Teacher : BaseEntityWithCode
    {
        #region ====== RELATIONSHIPS: ONE TO MANY - HAS MANY ======
        public IEnumerable<StudyGroup> StudyGroups { get; set; }
        #endregion

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
