using BBBWebApiCodeFirst.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("BbbApiConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
        }

        public DbSet<User_type> user_types { get; set; }

        public DbSet<User> users { get; set; }
               
        public DbSet<Location> locations { get; set; }

        public DbSet<Shared_location> shared_locations { get; set; }

        public DbSet<Collected_data> collected_data { get; set; }

        public DbSet<Property_type> property_types { get; set; }

        public DbSet<Service> services { get; set; }

        public DbSet<Day_type> day_types { get; set; }

        public DbSet<Day> days { get; set; }

        public DbSet<In_activity> in_activitys { get; set; }

        public DbSet<Out_activity> out_activitys { get; set; }

        public DbSet<In_day_period> in_day_periods { get; set; }

        public DbSet<Out_day_period> out_day_periods { get; set; }
       

    }
}
