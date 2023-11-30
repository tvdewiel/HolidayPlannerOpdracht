using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Model
{
    public class Stay
    {
        public Stay(DateTime arrivalDate, string location, Hotel hotel, int nrOfDays)
        {
            ArrivalDate = arrivalDate;
            Location = location;
            Hotel = hotel;
            NrOfDays = nrOfDays;
        }
        public Stay(int id, DateTime arrivalDate, string location, Hotel hotel, int nrOfDays)
        {
            Id = id;
            ArrivalDate = arrivalDate;
            Location = location;
            Hotel = hotel;
            NrOfDays = nrOfDays;
        }

        public int? Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Location { get; set; }
        public Hotel Hotel { get; set; }
        public int NrOfDays { get; set; }
       
        public bool Overlaps(Stay stay)
        {           
            if (ArrivalDate < stay.ArrivalDate.AddDays(stay.NrOfDays) && ArrivalDate.AddDays(NrOfDays) > stay.ArrivalDate)
                {  return true; }
            else
                { return false; }
        }
        public override string ToString()
        {
            return $"{Id},{ArrivalDate},{NrOfDays},{Location},{Hotel}";
        }
    }
}
