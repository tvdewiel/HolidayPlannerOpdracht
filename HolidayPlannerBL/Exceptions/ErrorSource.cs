using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Exceptions
{
    public class ErrorSource
    {
        public ErrorSource(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
        }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public override string ToString()
        {
            return $"(Class:{ClassName},Method:{MethodName})";
        }
    }
}
