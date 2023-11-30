using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Model
{
    public class Hotel
    {
        public Hotel(int id, string name, string address, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Hotel hotel &&
                   Id == hotel.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public override string ToString()
        {
            return $"{Id},{Name},{Address},{Email}";
        }
    }
}
