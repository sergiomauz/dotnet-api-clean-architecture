using Microsoft.AspNetCore.Mvc;


namespace Application.Commons.RequestParams
{
    public abstract class IdRequestParam
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
