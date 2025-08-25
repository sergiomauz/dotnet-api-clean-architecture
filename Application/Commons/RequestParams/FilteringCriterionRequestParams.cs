using System.Text.Json.Serialization;


namespace Application.Commons.RequestParams
{
    public class FilteringCriterionRequestParams
    {
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        [JsonPropertyName("operand")]
        public object? Operand { get; set; }
    }
}
