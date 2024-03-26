namespace WebApplicationAPI.DTOs
{
    public class WorkShiftDTO
    {
        public int ShiftID { get; set; }
        public string? NameShift { get; set; }
        public string? DescriptionShift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
