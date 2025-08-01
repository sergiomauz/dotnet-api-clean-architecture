using System.Net;


namespace Application.Commons.Exceptions
{
    public class ConflictValidationException : Exception
    {
        public string PropertyName { get; set; }
        public string CodeError { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ConflictValidationException(HttpStatusCode statusCode, string propertyName, string codeError, string messageError) : base(messageError)
        {
            PropertyName = propertyName;
            CodeError = codeError;
            StatusCode = statusCode;
        }
    }
}
