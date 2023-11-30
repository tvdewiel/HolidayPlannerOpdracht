using HolidayPlannerBL.Exceptions;

namespace HolidayPlannerREST.Middleware
{
    public class ServiceErrorResponse : ErrorResponse
    {
        public ServiceErrorResponse(int statusCode, string message, Error error, string uri, string method, string body) : base(statusCode,message)
        {
            Error = error;
            Uri = uri;
            Method = method;
            Body = body;
        }
        public Error Error { get; set; }
        public string Uri { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
    }
}
