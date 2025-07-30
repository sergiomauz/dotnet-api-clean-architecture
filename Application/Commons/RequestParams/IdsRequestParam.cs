using System.Text.Json.Serialization;


namespace Application.Commons.RequestParams
{
    public class IdsRequestParam
    {
        [JsonPropertyName("ids")]
        public List<string> Ids { get; set; }
    }
}
