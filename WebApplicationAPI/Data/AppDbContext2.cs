using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models.Certificate;

namespace WebApplicationAPI.Data
{
    public class AppDbContext2(DbContextOptions<AppDbContext2> options) : DbContext(options)

    {
        public DbSet<Area> Area { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<AreaRegion> AreaRegion { get; set; }
        public DbSet<OndutyListLocations> OndutyListLocations { get; set; }
        public DbSet<UserBeforeLoading> UserBeforeLoading { get; set; } 
    }
   
}
