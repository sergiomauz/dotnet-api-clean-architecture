using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;


namespace Application.Commons.RequestParams
{
    public class PaginationRequestParams
    {
        [FromQuery(Name = "current_page"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CurrentPage { get; set; }

        [FromQuery(Name = "page_size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PageSize { get; set; }
    }
}
