namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// Ca làm việc
    /// </summary>
    public class WorkShiftDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ShiftID { get; set; }
        /// <summary>
        /// Tên 
        /// </summary>
        public string? NameShift { get; set; }
        /// <summary>
        /// Miêu ta
        /// </summary>
        public string? DescriptionShift { get; set; }
        /// <summary>
        /// Giờ bắt đầu
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Giờ kết thúc
        /// </summary>
        public TimeSpan EndTime { get; set; }
    }
}
