using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Nhân viên trong ca trực
        /// </summary>
        public DbSet<Employee> Employee { get; set; }
        /// <summary>
        /// Ca làm việc
        /// </summary>
        public DbSet<WorkShift> WorkShift { get; set; }
        /// <summary>
        /// Địa điểm làm việc   
        /// </summary>       
        public DbSet<Locations> Locations { get; set; }
        /// <summary>
        /// Sắp xếp công ca 
        /// </summary>
        public DbSet<WorkSchedules> WorkSchedules { get; set; }
        /// <summary>
        /// Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>()
                .Property(p => p.ListID)
                .ValueGeneratedOnAdd();
        }


    }
}

