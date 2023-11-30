using HolidayPlannerDL.Model;
using HolidayPlannerDL.Repositories;

namespace ConsoleAppDLtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string conn = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=HolidayPlanner;Integrated Security=True;TrustServerCertificate=True";
            //HolidayContext ctx=new HolidayContext(conn);
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();
            HolidaysRepositoryEF repo = new HolidaysRepositoryEF(conn);
            var res=repo.GetCustomerHolidays(1);
            Console.WriteLine("end");
        }
    }
}