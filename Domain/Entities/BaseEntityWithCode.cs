namespace Domain.Entities
{
    public abstract class BaseEntityWithCode : BaseEntityWithId
    {
        public string? Code { get; set; }
    }
}
