using HolidayPlannerBL.Exceptions;

namespace HolidayPlannerREST.Middleware
{
    public class DomainErrorResponse : ErrorResponse
    {
        public DomainErrorResponse(int StatusCode,string Message,Error error) : base(StatusCode,Message)
        {
            Error = error;
        }

        public Error Error { get; set; }
    }
}
