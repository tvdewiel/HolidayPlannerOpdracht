using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Model
{
    public class HotelEF
    {
        public HotelEF(int id, string name, string address, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
        }
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
