using Commons.Enums;


namespace Application.Commons.Queries
{
    public class FilteringCriterionQuery
    {
        public FilterOperator Operator { get; set; }
        public object? Value { get; set; }
    }
}
