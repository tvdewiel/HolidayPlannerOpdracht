namespace HolidayPlannerREST.Middleware
{
    public class InfrastructureErrorResponse : ErrorResponse
    {
        public InfrastructureErrorResponse(int statusCode, string message) : base(statusCode, message) { }

    }
}
