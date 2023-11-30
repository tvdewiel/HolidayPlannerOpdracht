using HolidayPlannerBL.Exceptions;
using HolidayPlannerBL.Model;

namespace TestBL
{
    public class UnitTestHolidays
    {
        //gooit ex als stay al in de lijst zit
        [Fact]
        public void Test_AddStay_Exception_AlreadyInList()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            DateTime date3 = new DateTime(2023, 5, 17);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(date1, "Gent", hotel, 1);
            Stay stay2 = new Stay(date1, "Gent", hotel, 1);
            Holidays holidays = new Holidays("Gent city trip", 3, date1, date3, customer);
            holidays.AddStay(stay1);
            var ex=Assert.Throws<DomainModelException>(()=>holidays.AddStay(stay2));
            Assert.Equal("Holidays-AddStay-Duplicate", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "AddStay"), ex.Sources);
        }
        //gooit exception als stay niet in datuminterval ligt
        [Fact]
        public void Test_AddStay_Exception_IncorrectDate()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 17);
            DateTime date3 = new DateTime(2023, 5, 18);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(date3, "Gent", hotel, 1);
            Stay stay2 = new Stay(date1, "Gent", hotel, 3);
            Holidays holidays = new Holidays("Gent city trip", 3, date1, date2, customer);

            var ex = Assert.Throws<DomainModelException>(() => holidays.AddStay(stay1));
            Assert.Equal("Holidays-AddStay-NotInHolidays", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "AddStay"), ex.Sources);

            ex = Assert.Throws<DomainModelException>(() => holidays.AddStay(stay2));
            Assert.Equal("Holidays-AddStay-NotInHolidays", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "AddStay"), ex.Sources);
        }
        //gooit exception als een stay overlapt
        [Fact]
        public void Test_AddStay_Exception_Overlap()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            DateTime date3 = new DateTime(2023, 5, 19);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(date1, "Gent", hotel, 2);
            Stay stay2 = new Stay(date2, "Gent", hotel, 1);
            Holidays holidays = new Holidays("Gent city trip", 3, date1, date3, customer);
            holidays.AddStay(stay1);
            var ex = Assert.Throws<DomainModelException>(() => holidays.AddStay(stay2));
            Assert.Equal("Holidays-AddStay-Overlap", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "AddStay"), ex.Sources);
        }
        //happy path
        [Fact]
        public void Test_AddStay_Correct()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            DateTime date3 = new DateTime(2023, 5, 19);
            DateTime date4 = new DateTime(2023, 5, 27);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(date1, "Gent", hotel, 1);
            Stay stay2 = new Stay(date2, "Gent", hotel, 2);
            Stay stay3 = new Stay(date3, "Gent", hotel, 3);
            Holidays holidays = new Holidays("Gent city trip", 3, date1, date4, customer);
            holidays.AddStay(stay1);
            holidays.AddStay(stay2);
            holidays.AddStay(stay3);
            Assert.Equal(3,holidays.Stays.Count);
            Assert.Contains(stay1,holidays.Stays);
            Assert.Contains(stay2, holidays.Stays);
            Assert.Contains(stay3, holidays.Stays);
        }
        [Fact]
        public void Test_RemoveStay_Exception()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            DateTime date3 = new DateTime(2023, 5, 17);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(1,date1, "Gent", hotel, 1);
            Stay stay2 = new Stay(2,date1, "Gent", hotel, 1);
            Holidays holidays = new Holidays("Gent city trip", 3, date1, date3, customer);
            holidays.AddStay(stay1);
            var ex = Assert.Throws<DomainModelException>(() => holidays.RemoveStay(stay2));
            Assert.Equal("Holidays-RemoveStay", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "RemoveStay"), ex.Sources);

            stay1 = new Stay(date1, "Aalst", hotel, 1);
            ex = Assert.Throws<DomainModelException>(() => holidays.RemoveStay(stay1));
            Assert.Equal("Holidays-RemoveStay", ex.Message);
            Assert.Contains(new ErrorSource("Holidays", "RemoveStay"), ex.Sources);
        }
        [Fact]
        public void Test_RemoveStay_Correct()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            DateTime date3 = new DateTime(2023, 5, 19);
            DateTime date4 = new DateTime(2023, 5, 21);
            DateTime date5 = new DateTime(2023, 5, 27);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Stay stay1 = new Stay(1,date1, "Gent", hotel, 1);
            Stay stay2 = new Stay(2,date2, "Gent", hotel, 1);
            Stay stay3 = new Stay(3,date3, "Gent", hotel, 2);
            Stay stay4 = new Stay(4, date4, "Gent", hotel, 2);

            Holidays holidays = new Holidays("Gent city trip", 3, date1, date5, customer);
            holidays.AddStay(stay1);
            holidays.AddStay(stay2);
            holidays.AddStay(stay3);
            holidays.AddStay(stay4);
            Assert.Equal(4, holidays.Stays.Count);
            Assert.Contains(stay1, holidays.Stays);
            Assert.Contains(stay2, holidays.Stays);
            Assert.Contains(stay3, holidays.Stays);
            Assert.Contains(stay4, holidays.Stays);

            holidays.RemoveStay(stay1);

            Assert.Equal(3, holidays.Stays.Count);
            Assert.DoesNotContain(stay1, holidays.Stays);
            Assert.Contains(stay2, holidays.Stays);
            Assert.Contains(stay3, holidays.Stays);
            Assert.Contains(stay4, holidays.Stays);

            Stay stay5 = new Stay(2, date2, "Gent", hotel, 2);

            holidays.RemoveStay(stay5);

            Assert.Equal(2, holidays.Stays.Count);
            Assert.DoesNotContain(stay5, holidays.Stays);
            Assert.Contains(stay3, holidays.Stays);
            Assert.Contains(stay4, holidays.Stays);

            stay5 = new Stay(date3, "Gent", hotel, 2);

            holidays.RemoveStay(stay5);

            Assert.Equal(1, holidays.Stays.Count);
            Assert.DoesNotContain(stay5, holidays.Stays);
            Assert.Contains(stay4, holidays.Stays);
        }
        [Fact]
        public void Test_ctor_Exception()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");

            Assert.Throws<DomainModelException>(() => new Holidays("Gent city trip", 3, date2, date2, customer));
        }
        [Fact]
        public void Test_StartDate_Exception()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Holidays h=new Holidays("Gent city trip", 3, date1, date2, customer);

            Assert.Throws<DomainModelException>(() =>h.StartDate=date2);
        }
        [Fact]
        public void Test_EndDate_Exception()
        {
            DateTime date1 = new DateTime(2023, 5, 15);
            DateTime date2 = new DateTime(2023, 5, 16);
            Hotel hotel = new Hotel(10, "Ibis", "Gent centrum", "ibis@gmail");
            Customer customer = new Customer("Jos", "Berlin", "jos@gmail");
            Holidays h = new Holidays("Gent city trip", 3, date1, date2, customer);

            Assert.Throws<DomainModelException>(() => h.EndDate = date1);
        }
    }
}