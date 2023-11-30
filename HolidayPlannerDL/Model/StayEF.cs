using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Model
{
    [Table("Stay")]
    public class StayEF
    {
        public StayEF()
        {
        }

        public StayEF(DateTime arrivalDate, string location, HotelEF hotel, int nrOfDays)
        {
            ArrivalDate = arrivalDate;
            Location = location;
            Hotel = hotel;
            NrOfDays = nrOfDays;
        }
        public StayEF(int id, DateTime arrivalDate, string location, HotelEF hotel, int nrOfDays)
        {
            Id = id;
            ArrivalDate = arrivalDate;
            Location = location;
            Hotel = hotel;
            NrOfDays = nrOfDays;
        }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        [MaxLength(250)]
        public string Location { get; set; }
        [Required]
        //public int HotelId { get; set; }
        public HotelEF Hotel { get; set; }
        public int NrOfDays { get; set; }
        
    }
}
