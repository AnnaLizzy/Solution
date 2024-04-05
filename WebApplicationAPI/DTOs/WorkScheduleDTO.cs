namespace WebApplicationAPI.DTOs
{
    public class WorkScheduleDTO
    {
        public int SchedulesID { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int ShiftID { get; set; }
        public string? ShiftName { get; set; }
        public int ListId { get; set; }
        public string? LocationID { get; set; }
        public string? LocationName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Frequency { get; set; }
        public int Interval { get; set; }
        public string? ByWeekday { get; set;}
    }
}
