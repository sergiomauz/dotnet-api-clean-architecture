namespace Domain
{
    public class Student : BasicEntity
    {
        public string Code { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
