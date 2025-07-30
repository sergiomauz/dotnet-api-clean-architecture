using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;


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
