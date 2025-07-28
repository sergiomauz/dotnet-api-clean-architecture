using System.Text.Json.Serialization;


namespace Application.Commons.RequestParams
{
    public class ObjectRequestParams<TFiltering, TOrdering> : PaginatedRequestParams
    {
        [JsonPropertyName("filtering_criteria")]
        public TFiltering? FilteringCriteria { get; set; }

        [JsonPropertyName("ordering_criteria")]
        public TOrdering? OrderingCriteria { get; set; }
    }
}
