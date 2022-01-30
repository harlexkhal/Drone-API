using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DroneAPI.Entities;

namespace DroneAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("APIDatabase"));
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<MedicationItem> MedicationItems { get; set; }
    }
}