namespace Domain
{
    public abstract class BaseEntityWithCode : BaseEntityWithId
    {
        public string? Code { get; set; }
    }
}
