
using HolidayPlannerBL.Interfaces;
using HolidayPlannerBL.Managers;
using HolidayPlannerDL.Repositories;
using HolidayPlannerREST.Middleware;

namespace HolidayPlannerREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("HolidaysDatabase");
            // Add services to the container.

            builder.Services.AddSingleton<HolidaysManager>();
            builder.Services.AddSingleton<IHolidaysRepository>(x=>new HolidaysRepositoryEF(connectionString));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseLogURLMiddleware();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}