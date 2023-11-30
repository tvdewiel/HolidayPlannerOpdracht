using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Model
{
    public class HolidaysEF
    {
        public HolidaysEF()
        {
        }

        public HolidaysEF(string name, int nrOfParticipants, DateTime startDate, DateTime endDate, CustomerEF customer)
        {
            Name = name;
            NrOfParticipants = nrOfParticipants;
            StartDate = startDate;
            EndDate = endDate;
            Customer = customer;
        }

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int NrOfParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public CustomerEF Customer { get; set; }
        public List<StayEF> Stays { get; set; } = new List<StayEF>();
    }
}
