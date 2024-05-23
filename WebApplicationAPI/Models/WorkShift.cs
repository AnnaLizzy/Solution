using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    /// <summary>
    /// work shift
    /// </summary>
    public class WorkShift
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int ShiftID { get; set; }
        /// <summary>
        /// name shift
        /// </summary>
        public string? NameShift { get; set; }
        /// <summary>
        /// detail shift
        /// </summary>
        public string? DescriptionShift { get; set; }
        /// <summary>
        /// time start
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// time end
        /// </summary>
        public TimeSpan EndTime { get; set; }
    }
}
