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
    public static class MapToDomain
    {
        public static Customer MapCustomer(CustomerEF data)
        { 
            try
            {
                return new Customer(data.Id,data.Name,data.Address,data.Email);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapCustomer")); throw ex;
            }
            catch (Exception) { throw; }
        }
        public static Hotel MapHotel(HotelEF data)
        {
            try
            {
                return new Hotel(data.Id, data.Name, data.Address, data.Email);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapHotel")); throw ex;
            }
            catch (Exception) { throw; }
        }
        public static Holidays MapHoliday(HolidaysEF data)
        {
            try
            {
                Customer customer=MapToDomain.MapCustomer(data.Customer);
                List<Stay> stays=data.Stays.Select(x=>MapToDomain.MapStay(x)).ToList();
                return new Holidays(data.Id, data.Name,data.NrOfParticipants,data.StartDate,data.EndDate,customer,stays);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapHoliday")); throw ex;
            }
            catch (Exception) { throw; }
        }
        private static Stay MapStay(StayEF data)
        {
            try
            {
                return new Stay(data.Id, data.ArrivalDate, data.Location, MapToDomain.MapHotel(data.Hotel),data.NrOfDays);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapHotel")); throw ex;
            }
            catch (Exception) { throw; }
        }
    }
}
