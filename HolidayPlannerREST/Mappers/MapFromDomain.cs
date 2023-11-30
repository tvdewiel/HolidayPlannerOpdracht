using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Model;
using HolidayPlannerDL.Model;
using HolidayPlannerREST.Model.Input;
using HolidayPlannerREST.Model.Output;

namespace HolidayPlannerREST.Mappers
{
    public static class MapFromDomain
    {
        public static CustomerRESTOutputDTO MapCustomer(Customer customer)
        {
            try
            {
                return new CustomerRESTOutputDTO(customer.Id,customer.Name, customer.Address, customer.Email);
            }
            catch (Exception e) {
                var ex = new ServiceException("PostStay",e);
                ex.Sources.Add(new ErrorSource("MapFromDomain", "MapCustomer"));                
                ex.Error.Values.Add(new PropertyInfo("customer", customer));
                throw ex;
            }
        }
    }
}
