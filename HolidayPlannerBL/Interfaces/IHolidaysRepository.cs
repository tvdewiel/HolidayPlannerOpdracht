using HolidayPlannerBL.DTO;
using HolidayPlannerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Interfaces
{
    public interface IHolidaysRepository
    {
        void AddCustomer(Customer customer);
        void AddHolidays(Holidays holidays);
        void AddStay(Holidays holidays, Stay stay);
        bool ExistsCustomer(int id);
        bool ExistsCustomerEmail(string email);
        Customer GetCustomer(int id);
        CustomerHolidaysDTO GetCustomerHolidays(int id);
        Holidays GetHoliday(int holidayId);
        Hotel GetHotel(int hotelId);
    }
}
