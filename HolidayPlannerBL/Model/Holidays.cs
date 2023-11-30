using HolidayPlannerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HolidayPlannerBL.Model
{
    public class Holidays
    {
        public Holidays(string name, int nrOfParticipants, DateTime startDate, DateTime endDate, Customer customer)
        {

        }
        public Holidays(int id, string name, int nrParticipants, DateTime startDate, DateTime endDate, Customer customer, List<Stay> stays)
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        private int nrParticipants;
        public int NrOfParticipants { 
            get { return nrParticipants; } 
            set { if (value <= 0)
                {
                    var ex = new DomainModelException("Holidays-NrOfParticipants");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(NrOfParticipants)));
                    ex.Error = new Error("NrOfParticipants is invalid");
                    ex.Error.Values.Add(new PropertyInfo("NrOfParticipants", value));
                    throw ex;
                }
                nrParticipants = value;
                } }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public Customer Customer { get; set; }
        private List<Stay> stays { get; set; } = new List<Stay>();
        public IReadOnlyList<Stay> Stays { get {  return stays; } }
        public void AddStay(Stay stay)
        {

        }
        public void RemoveStay(Stay stay)
        {

        }
    }
}
