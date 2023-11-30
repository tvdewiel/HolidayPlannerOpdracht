using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Model;
using HolidayPlannerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidayPlannerDL.Mappers
{
    public static class MapFromDomain
    {
        public static CustomerEF MapCustomer(Customer customer, HolidayContext context)
        {
            try
            {
                if (customer.Id!=null) return context.Customer.Find(customer.Id);
                return new CustomerEF(customer.Name, customer.Address, customer.Email);
            }
            //TODO voeg bron toe voor debuggen
            catch (Exception) { throw; }
        }
        public static HolidaysEF MapHolidays(Holidays holidays, HolidayContext context)
        {
            try
            {
                return new HolidaysEF(holidays.Name, holidays.NrOfParticipants, holidays.StartDate, holidays.EndDate, MapFromDomain.MapCustomer(holidays.Customer,context));
            }
            catch (Exception) { throw; }
        }
        public static StayEF MapStay(Stay stay)
        {
            try
            {
                return new StayEF(stay.ArrivalDate,stay.Location,MapFromDomain.MapHotel(stay.Hotel),stay.NrOfDays);
            }
            catch (Exception) { throw; }
        }
        public static HotelEF MapHotel(Hotel hotel)
        {
            try
            {
                //moet bestaand hotel zijn
                return new HotelEF(hotel.Id,hotel.Name,hotel.Address,hotel.Email);
            }
            catch (Exception) { throw; }
        }
    }
}
