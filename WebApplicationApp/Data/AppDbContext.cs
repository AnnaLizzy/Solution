namespace WebApplicationApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkShift> WorkShift { get; set; }
        public DbSet<Shift> Shifts { get; set; }

    }
}
