using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    public class WorkSchedules
    {
        [Key]
        public int SchedulesID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public string? LocationID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
