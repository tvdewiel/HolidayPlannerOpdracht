using HolidayPlannerBL.DTO;
using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Interfaces;
using HolidayPlannerBL.Model;
using HolidayPlannerDL.Mappers;
using HolidayPlannerDL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Repositories
{
    public class HolidaysRepositoryEF : IHolidaysRepository
    {
        private string connectionString;
        private HolidayContext context;

        public HolidaysRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
            context=new HolidayContext(connectionString);
        }
        private void SaveAndClear()
        {
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                CustomerEF customerEF = MapFromDomain.MapCustomer(customer,context);
                context.Customer.Add(customerEF);
                SaveAndClear();
                customer.Id= customerEF.Id;                
            }
            catch (Exception ex) { 
                var iex= new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddCustomer)));
                throw iex;
            }
        }
        public bool ExistsCustomer(int id)
        {
            try
            {
                return context.Customer.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ExistsCustomer)));
                throw iex;
            }
        }
        public Customer GetCustomer(int id)
        {
            try
            {
                return MapToDomain.MapCustomer(context.Customer.Where(x => x.Id == id).AsNoTracking().First());
            }
            catch (DomainModelException dex) {               
                dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomer)));                
                throw dex;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomer)));
                throw iex;
            }
        }
        public void AddHolidays(Holidays holidays)
        {
            try
            {
                HolidaysEF holidaysEF = MapFromDomain.MapHolidays(holidays, context);
                context.Holidays.Add(holidaysEF);
                SaveAndClear();
                holidays.Id = holidaysEF.Id;

            }
            catch (DomainModelException dex)
            {
                dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddHolidays)));
                throw dex;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddHolidays)));
                throw iex;
            }
        }
        public Hotel GetHotel(int id)
        {
            try
            {
                return MapToDomain.MapHotel(context.Hotel.Where(x => x.Id == id).AsNoTracking().First());
            }
            catch (DomainModelException dex)
            {
                dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHotel)));
                throw dex;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHotel)));
                throw iex;
            }
        }
        public Holidays GetHoliday(int id)
        {
            try
            {
                return MapToDomain.MapHoliday(context.Holidays
                    .Include(x=>x.Customer)
                    .Include(x=>x.Stays).ThenInclude(x=>x.Hotel)
                    .Where(x => x.Id == id).AsNoTracking().First());
            }
            catch (DomainModelException dex)
            {
                dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHoliday)));
                throw dex;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetHoliday)));
                throw iex;
            }
        }
        public void AddStay(Holidays holidays, Stay stay)
        {
            try
            {
                StayEF stayEF = MapFromDomain.MapStay(stay);
                HolidaysEF holidaysEF=context.Holidays.Find(holidays.Id);
                holidaysEF.Stays.Add(stayEF);
                SaveAndClear();
                stay.Id = stayEF.Id;

            }
            //catch (DomainModelException dex)
            //{
            //    dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddStay)));
            //    throw dex;
            //}
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddStay)));
                throw iex;
            }
        }
        public bool ExistsCustomerEmail(string email)
        {
            try
            {
                return context.Customer.Any(x => x.Email == email);
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ExistsCustomerEmail)));
                throw iex;
            }
        }
        public CustomerHolidaysDTO (int id)
        {
            try
            {
                
            }
            catch (DomainModelException dex)
            {
                dex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomer)));
                throw dex;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("HolidaysRepositoryEF", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetCustomerHolidays)));
                throw iex;
            }
        }
    }
}
