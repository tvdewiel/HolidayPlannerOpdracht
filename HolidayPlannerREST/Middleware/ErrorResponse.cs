namespace HolidayPlannerREST.Middleware
{
    public abstract class ErrorResponse
    {
        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
