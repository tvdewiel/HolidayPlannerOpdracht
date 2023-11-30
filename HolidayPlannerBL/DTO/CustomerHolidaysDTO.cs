using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Model;

namespace HolidayPlannerBL.DTO
{
    public class CustomerHolidaysDTO
    {
        public CustomerHolidaysDTO(int id, string name, string address, string email, List<HolidaysDTO> holidays)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            Holidays = holidays;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<HolidaysDTO> Holidays { get; set; }        
    }
}
