using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Managers;
using HolidayPlannerBL.Model;
using HolidayPlannerREST.Model.Input;

namespace HolidayPlannerREST.Mappers
{
    public static class MapToDomain
    {
        public static Customer MapCustomer(CustomerRESTInputDTO dTO)
        {
            try
            {
                return new Customer(dTO.Name, dTO.Address, dTO.Email);
            }
            catch(DomainModelException ex) { 
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapCustomer")); throw ex; }
            catch(Exception ex) { throw ex; }
        }

        public static Holidays MapHolidays(HolidaysRESTInputDTO dto,Customer customer)
        {
            try
            {
                return new Holidays(dto.Name,dto.NrOfParticipants,dto.StartDate,dto.EndDate,customer);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapHolidays")); throw ex;
            }
            catch (Exception ex) { throw ex; }
        }

        public static Stay MapStay(StayRESTInputDTO dto, HolidaysManager holidaysManager)
        {
            try
            {
                return new Stay(dto.ArrivalDate,dto.Location,holidaysManager.GetHotel(dto.HotelId),dto.NrOfDays);
            }
            catch (DomainModelException ex)
            {
                ex.Sources.Add(new ErrorSource("MapToDomain", "MapStay")); throw ex;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
