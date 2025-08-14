namespace Domain.Entities.Bases
{
    public abstract class BaseEntityWithGuid
    {
        public Guid? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
