using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;


namespace Application.Commons.RequestParams
{
    public class IdsRequestParam
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }

        [JsonPropertyName("ids")]
        public List<string>? Ids { get; set; }
    }
}
