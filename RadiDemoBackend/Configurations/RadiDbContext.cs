using Microsoft.EntityFrameworkCore;
using RadiDemoBackend.Configurations;
using RadiDemoBackend.Models;

namespace RadiDemoBackend.Configuration
{
    public class RadiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public RadiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("SampleDbConnection"));


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MeasurementConfiguration().Configure(modelBuilder.Entity<Measurement>());
        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
