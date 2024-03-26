using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    public class WorkShift
    {
        [Key]
        public int ShiftID { get; set; }
        public string? NameShift { get; set; }
        public string? DescriptionShift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
