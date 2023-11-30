using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Model;

namespace HolidayPlannerREST.Model.Output
{
    public class HolidaysRESTOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NrOfParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public List<StayRESTOutputDTO> Stays { get; set; } = new List<StayRESTOutputDTO>();
    }
}
