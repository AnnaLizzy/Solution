using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        
        public DbSet<Employee> Employee { get; set; }
        public DbSet<WorkShift> WorkShift { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<WorkSchedules> WorkSchedules { get; set; }

    }
}

