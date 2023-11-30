﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Exceptions
{
    public class PropertyInfo
    {
        public PropertyInfo(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return $"(Property Name:{Name},Value:{Value})";
        }
    }
}
