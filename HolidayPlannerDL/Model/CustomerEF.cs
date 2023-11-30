using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Model
{
    public class CustomerEF
    {
        public CustomerEF()
        {
        }

        public CustomerEF(string name, string? address, string email)
        {
            Name = name;
            Address = address;
            Email = email;
        }

        public CustomerEF(int id, string name, string? address, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
        }

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Address { get; set; }
        [MaxLength (100)]
        public string Email { get; set; }
    }
}
