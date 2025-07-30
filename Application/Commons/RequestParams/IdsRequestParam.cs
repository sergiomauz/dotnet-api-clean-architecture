using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;


namespace Application.Commons.RequestParams
{
    public class IdsRequestParam
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }

        [JsonPropertyName("ids")]
        public List<int>? Ids { get; set; }
    }
}
