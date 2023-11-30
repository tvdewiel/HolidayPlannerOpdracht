using HolidayPlannerBL.Model;

namespace HolidayPlannerREST.Model.Output
{
    public class StayRESTOutputDTO
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Location { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelEmail { get; set; }
        public int NrOfDays { get; set; }
    }
}
