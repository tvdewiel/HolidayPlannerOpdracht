using HolidayPlannerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Model
{
    public class Customer
    {
        private const int minNameLength = 2;
        private const int maxNameLength = 25;
        public Customer(string name, string address, string email)
        {
            SetName(name);
            Address = address;
            Email = email;
        }
        public Customer(int id, string name, string address, string email)
        {
            Id = id;
            SetName(name);
            Address = address;
            Email = email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var ex = new DomainModelException("customer-setname-IsNullOrWhiteSpace");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(SetName)));
                ex.Error = new Error("name is null or white space");
                ex.Error.Values.Add(new PropertyInfo("name", name));
                throw ex;
            }
            if (name.Length > maxNameLength || name.Length < minNameLength)
            {
                var ex = new DomainModelException("customer-setname-Length");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(SetName)));
                ex.Error = new Error($"name length not between {minNameLength} and {maxNameLength}");
                ex.Error.Values.Add(new PropertyInfo("name", name));
                ex.Error.Values.Add(new PropertyInfo("length", name.Length));
                throw ex;
            }
            if (char.IsLower(name[0]))
            {
                var ex = new DomainModelException("customer-setname-IsLower");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(SetName)));
                ex.Error = new Error("name does not start with upper case");
                ex.Error.Values.Add(new PropertyInfo("name", name));
                throw ex;
            }
            Name = name;
        }
    }
}
