using System.Net;

namespace EnterpriseClientService.Domain.Models
{
    public class Error
    {
        public Error(int statusCode, string message, string stackTrace) 
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = stackTrace;
        }

        public Error(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = string.Empty;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
