using HolidayPlannerBL.Model;

namespace HolidayPlannerREST.Model.Input
{
    public class HolidaysRESTInputDTO
    {
        public string Name { get; set; }
        public int NrOfParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int CustomerId { get; set; }
    }
}
