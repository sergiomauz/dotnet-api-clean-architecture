using System.Text.Json.Serialization;


namespace Api.Responses
{
    public class CustomExceptionResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("exception_details"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object> ExceptionDetails { get; set; }

        public CustomExceptionResponse(string message, Dictionary<string, object>? exceptionDetails = null)
        {
            Message = message;
            ExceptionDetails = exceptionDetails;
        }
    }
}
