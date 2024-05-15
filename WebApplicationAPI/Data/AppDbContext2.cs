using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models.Certificate;

namespace WebApplicationAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public class AppDbContext2(DbContextOptions<AppDbContext2> options) : DbContext(options)

    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Area> Area { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Region> Region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<AreaRegion> AreaRegion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<OndutyListLocations> OndutyListLocations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<UserBeforeLoading> UserBeforeLoding { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public DbSet<DoorPowerManager> DoorPowerManage { get; set; }
    }
   
}
