using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Managers;
using HolidayPlannerBL.Model;
using HolidayPlannerREST.Mappers;
using HolidayPlannerREST.Model.Input;
using HolidayPlannerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace HolidayPlannerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private HolidaysManager holidaysManager;

        public HolidaysController(HolidaysManager holidaysManager)
        {
            this.holidaysManager = holidaysManager;
        }
        #region customer
        [HttpGet("customer/{id}")]
        public ActionResult<CustomerRESTOutputDTO> GetCustomer(int customerId)
        {
            if (!holidaysManager.ExistsCustomer(customerId)) return NotFound(customerId);
            return Ok(MapFromDomain.MapCustomer(holidaysManager.GetCustomer(customerId)));
        }
        [HttpPost]
        [Route("customer")]
        public ActionResult<CustomerRESTOutputDTO> PostCustomer([FromBody] CustomerRESTInputDTO dto)
        {
            Customer customer = MapToDomain.MapCustomer(dto);
            holidaysManager.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, MapFromDomain.MapCustomer(customer));
        }
        [HttpDelete]
        [Route("customer/{id}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Route("customer/{id}")]
        public ActionResult<CustomerRESTOutputDTO> PutCustomer(int customerId, [FromBody] CustomerRESTInputDTO dto)
        { throw new NotImplementedException(); }
        #endregion
        #region holidays
        [HttpGet]
        [Route("customer/{customerId}/holidays/{holidayId}")]
        public ActionResult<HolidaysRESTOutputDTO> GetHolidays(int customerId,int holidayId)
        {
            return null;
        }
        [HttpGet]
        [Route("customer/{customerId}/Holidays")]
        public ActionResult<CustomerHolidaysDTO> GetCustomerHolidays(int customerId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("customer/{customerId}/Holidays")]
        public ActionResult<HolidaysRESTOutputDTO> PostHolidays(int customerId,[FromBody] HolidaysRESTInputDTO dto)
        {
            Holidays holidays = MapToDomain.MapHolidays(dto,holidaysManager.GetCustomer(customerId));
            holidaysManager.AddHolidays(holidays);
            return CreatedAtAction(nameof(GetHolidays),new {customerId=customerId, holidayId=holidays.Id},holidays);  
        }
        [HttpDelete]
        [Route("customer/{customerId}/holidays/{holidayId}")]
        public IActionResult DeleteHoliday(int customerId,int holidayId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Route("customer/{customerId}/holidays/{holidayId}")]
        public ActionResult<HolidaysRESTOutputDTO> PutHolidays(int customerId,int holidaysId,HolidaysRESTInputDTO dTO) 
        { throw new NotImplementedException(); }
        #endregion
        #region stay
        [HttpPost]
        [Route("customer/{customerId}/Holidays/{holidayId}/stay")]
        public ActionResult<HolidaysRESTOutputDTO> PostStay(int customerId,int holidayId, [FromBody] StayRESTInputDTO dto) 
        {
            Stay stay = MapToDomain.MapStay(dto,holidaysManager);
            Holidays holidays = holidaysManager.GetHoliday(holidayId);
            if (holidays.Customer.Id!=customerId)
            {
                var ex = new ServiceException("PostStay");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(PostStay)));
                ex.Error = new Error("Holidays doe not belong to customer");
                ex.Error.Values.Add(new PropertyInfo("customerIdURL",customerId));
                ex.Error.Values.Add(new PropertyInfo("customerIdHolidays", holidays.Customer.Id));
                throw ex;
            }
            holidaysManager.AddStay(holidays,stay);
            return CreatedAtAction(nameof(GetHolidays), new { customerId = customerId, holidayId = holidays.Id }, holidays);
        }
        [HttpDelete]
        [Route("customer/{customerId}/Holidays/{holidayId}/stay/{stayId}")]
        public IActionResult DeleteStay(int customerId,int holidayId,int stayId) 
        { throw new NotImplementedException(); }
        [HttpPut]
        [Route("customer/{customerId}/Holidays/{holidayId}/stay/{stayId}")]
        public ActionResult<HolidaysRESTOutputDTO> PutStay(int customerId,int holidayId,int StayId, [FromBody] StayRESTInputDTO dto) 
        {  throw new NotImplementedException(); }
        #endregion
    }
}
