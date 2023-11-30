using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Exceptions
{
    public class InfrastructureException : BLException
    {
        public InfrastructureException(string? message) : base(message)
        {
        }

        public InfrastructureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
