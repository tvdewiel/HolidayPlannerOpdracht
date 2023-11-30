using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Exceptions
{
    public class DomainModelException : BLException
    {
        public Error Error { get; set; }
        public DomainModelException(string? message) : base(message)
        {
        }
        public DomainModelException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
