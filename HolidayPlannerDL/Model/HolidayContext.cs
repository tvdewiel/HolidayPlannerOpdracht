using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerDL.Model
{
    public class HolidayContext : DbContext
    {
        private string connectionString;

        public HolidayContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<HolidaysEF> Holidays { get; set;}
        public DbSet<HotelEF> Hotel { get; set;}
        public DbSet<CustomerEF> Customer { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HolidaysEF>()
                .HasMany(x=>x.Stays)
                .WithOne().HasForeignKey("HolidaysId")
                .IsRequired(true);
        }
    }
}
