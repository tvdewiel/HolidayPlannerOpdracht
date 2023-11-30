using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.DTO
{
    public class HolidaysDTO
    {
        public HolidaysDTO(string name, int nrOfParticipants, DateTime startDate, DateTime endDate)
        {
            Name = name;
            NrOfParticipants = nrOfParticipants;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Name { get; set; }
        public int NrOfParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
