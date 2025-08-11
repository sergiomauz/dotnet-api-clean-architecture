using System.Text.Json;
using System.Collections;
using Commons.Enums;
using Application.Commons.Queries;


namespace Application.Commons.Validators
{
    public static class FilteringCriterionQueryValidator
    {
        private static object? _convertFromJsonElement(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt64(out long l))
                        return l;
                    if (element.TryGetDouble(out double d))
                        return d;
                    return null;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return element.GetBoolean();
                case JsonValueKind.Array:
                    return element.EnumerateArray().Select(_convertFromJsonElement).ToList();
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return null;
                default:
                    return element.ToString();
            }
        }

        private static bool _isNumber(object valueParam)
        {
            return valueParam is sbyte || valueParam is byte ||
                   valueParam is short || valueParam is ushort ||
                   valueParam is int || valueParam is uint ||
                   valueParam is long || valueParam is ulong ||
                   valueParam is float || valueParam is double ||
                   valueParam is decimal;
        }

        public static bool IsValid(FilteringCriterionQuery filteringCriterion)
        {
            if (filteringCriterion == null)
                return true;

            // Operator must not be null or invalid
            if (!Enum.IsDefined(typeof(FilterOperator), filteringCriterion.Operator))
                return false;

            // Value can be null
            if (filteringCriterion.Value == null)
                return true;

            var val = filteringCriterion.Value;

            // Try to get the real value if it is a JsonElement
            if (val is JsonElement jsonElement)
            {
                val = _convertFromJsonElement(jsonElement);
            }

            var valueType = val.GetType();

            // Is a boolean?
            if (valueType == typeof(bool))
            {
                return filteringCriterion.Operator == FilterOperator.Equals ||
                       filteringCriterion.Operator == FilterOperator.NotEquals;
            }

            // Is a number?
            if (_isNumber(val))
            {
                return filteringCriterion.Operator == FilterOperator.Equals ||
                       filteringCriterion.Operator == FilterOperator.NotEquals ||
                       filteringCriterion.Operator == FilterOperator.GreaterThan ||
                       filteringCriterion.Operator == FilterOperator.LessThan ||
                       filteringCriterion.Operator == FilterOperator.GreaterThanOrEqual ||
                       filteringCriterion.Operator == FilterOperator.LessThanOrEqual;
            }

            // Is a string?
            if (valueType == typeof(string))
            {
                string strVal = (string)val;

                // Check if it is a valid date or datetime
                if (DateTime.TryParse(strVal, out _))
                {
                    return filteringCriterion.Operator == FilterOperator.Equals ||
                           filteringCriterion.Operator == FilterOperator.NotEquals ||
                           filteringCriterion.Operator == FilterOperator.GreaterThan ||
                           filteringCriterion.Operator == FilterOperator.LessThan ||
                           filteringCriterion.Operator == FilterOperator.GreaterThanOrEqual ||
                           filteringCriterion.Operator == FilterOperator.LessThanOrEqual;
                }
                else
                {
                    // Regular string
                    return filteringCriterion.Operator == FilterOperator.Equals ||
                           filteringCriterion.Operator == FilterOperator.NotEquals ||
                           filteringCriterion.Operator == FilterOperator.Contains ||
                           filteringCriterion.Operator == FilterOperator.StartsWith ||
                           filteringCriterion.Operator == FilterOperator.EndsWith;
                }
            }

            // Is a DateTime?
            if (valueType == typeof(DateTime))
            {
                return filteringCriterion.Operator == FilterOperator.Equals ||
                       filteringCriterion.Operator == FilterOperator.NotEquals ||
                       filteringCriterion.Operator == FilterOperator.GreaterThan ||
                       filteringCriterion.Operator == FilterOperator.LessThan ||
                       filteringCriterion.Operator == FilterOperator.GreaterThanOrEqual ||
                       filteringCriterion.Operator == FilterOperator.LessThanOrEqual;
            }

            // Is an array?
            if (val is IEnumerable enumerable && !(val is string))
            {
                var list = enumerable.Cast<object>().ToList();

                if (list.Count > 0)
                {
                    var firstElementType = list.First()?.GetType();

                    // All elements must be the same type
                    if (!list.All(x => x?.GetType() == firstElementType))
                        return false;

                    // Special case: all elements are strings and valid dates
                    if (firstElementType == typeof(string))
                    {
                        var allAreValidDates = list.All(x => DateTime.TryParse(x?.ToString(), out _));
                        if (allAreValidDates)
                            return filteringCriterion.Operator == FilterOperator.In;
                    }
                }

                // Only "In" is valid for any array
                return filteringCriterion.Operator == FilterOperator.In;
            }

            // If none of the cases apply, the object is invalid
            return false;
        }
    }
}
