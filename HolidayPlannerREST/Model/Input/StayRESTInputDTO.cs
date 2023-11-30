using HolidayPlannerBL.Model;

namespace HolidayPlannerREST.Model.Input
{
    public class StayRESTInputDTO
    {
        public StayRESTInputDTO(DateTime arrivalDate, string location, int hotelId, int nrOfDays)
        {
            ArrivalDate = arrivalDate;
            Location = location;
            HotelId = hotelId;
            NrOfDays = nrOfDays;
        }

        public DateTime ArrivalDate { get; set; }
        public string Location { get; set; }
        public int HotelId { get; set; }
        public int NrOfDays { get; set; }
    }
}
