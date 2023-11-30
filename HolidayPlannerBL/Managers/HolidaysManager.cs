using HolidayPlannerBL.DTO;
using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Interfaces;
using HolidayPlannerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerBL.Managers
{
    public class HolidaysManager
    {
        private IHolidaysRepository holidaysRepository;

        public HolidaysManager(IHolidaysRepository holidaysRepository)
        {
            this.holidaysRepository = holidaysRepository;
        }
        public Customer GetCustomer(int id)
        {
            try
            {
                return holidaysRepository.GetCustomer(id);
            }
            catch (BLException ex) 
            { 
                ex.Sources.Add(new ErrorSource(this.GetType().Name,nameof(GetCustomer))); 
                throw ex; 
            }
            catch(Exception ex) 
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomer)));
                throw bex; 
            }
        }
        public bool ExistsCustomer(int id)
        {
            try
            {
                return holidaysRepository.ExistsCustomer(id);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ExistsCustomer)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ExistsCustomer)));
                throw bex;
            }
        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                //check op dubbels
                if (holidaysRepository.ExistsCustomerEmail(customer.Email))
                {
                    var ex = new DomainModelException("HolidaysManager-AddCustomer-Email");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddCustomer)));
                    ex.Error = new Error("customer email already exists");
                    ex.Error.Values.Add(new PropertyInfo("CustomerEmail", customer.Email));
                    throw ex;
                }
                holidaysRepository.AddCustomer(customer);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddCustomer)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddCustomer)));
                throw bex;
            }
        }
        public void AddHolidays(Holidays holidays)
        {
            try
            {
                holidaysRepository.AddHolidays(holidays);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddHolidays)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddHolidays)));
                throw bex;
            }
        }
        public Hotel GetHotel(int hotelId)
        {
            try
            {
                return holidaysRepository.GetHotel(hotelId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHotel)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHotel)));
                throw bex;
            }
        }
        public Holidays GetHoliday(int holidayId)
        {
            try
            {
                return holidaysRepository.GetHoliday(holidayId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHoliday)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHoliday)));
                throw bex;
            }
        }
        public void AddStay(Holidays holidays,Stay stay)
        {
            try
            {
                holidays.AddStay(stay); //check business rules
                holidaysRepository.AddStay(holidays, stay);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddStay)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddStay)));
                throw bex;
            }
        }
        public CustomerHolidaysDTO GetCustomerHolidays(int id)
        {
            try
            {
                return holidaysRepository.GetCustomerHolidays(id);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomerHolidays)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomerHolidays)));
                throw bex;
            }
        }
    }
}
