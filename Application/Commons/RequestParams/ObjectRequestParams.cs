using System.Text.Json.Serialization;


namespace Application.Commons.RequestParams
{
    public class ObjectRequestParams<TFiltering, TOrdering> : PaginationRequestParams
    {
        [JsonPropertyName("filtering_criteria")]
        public TFiltering? FilteringCriteria { get; set; }

        [JsonPropertyName("ordering_criteria")]
        public TOrdering? OrderingCriteria { get; set; }
    }
}
