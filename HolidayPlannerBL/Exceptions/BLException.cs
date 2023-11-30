using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Exceptions
{
    public class BLException : Exception
    {
        public List<ErrorSource> Sources = new List<ErrorSource>();
        public BLException(string? message) : base(message)
        {
        }
        public BLException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
