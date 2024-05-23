using WebApplicationAPI.Models.Enum;

namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// WorkScheduleDTO
    /// </summary>
    public class WorkScheduleDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ScheduleID { get; set; }
        /// <summary>
        /// ma nhan vien lam viec
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// Ten nhan vien lam viec
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// ma ca lam viec
        /// </summary>

        public int ShiftID { get; set; }
        /// <summary>
        /// shift name
        /// </summary>
        public string? ShiftName { get; set; }
        /// <summary>
        /// ma dia diem lam viec
        /// </summary>
        public int ListID { get; set; }
        /// <summary>
        /// ten dia diem
        /// </summary>
        public string? LocationName { get; set; }
        /// <summary>
        /// Mã người làm đơn
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// Bussiness Group
        /// </summary>
        public string? BG { get; set; }
        /// <summary>
        /// Bussiness Unit
        /// </summary>
        public string? BU { get; set; }
        /// <summary>
        /// So dien thoai nguoi lam don
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Ngay bat dau cua lich lam viec
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ngay ket thuc cua lich lam viec
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Tần suất theo tuần, tháng, năm
        /// </summary>
        public string? Frequency { get; set; }
        /// <summary>
        /// Khoảng cách giữa các lần lặp
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// Ngày trong tuần
        /// </summary>
        public string? ByWeekday { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Mã chi phí 
        /// </summary>
        public string? BUCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// Trạng thái ký
        /// </summary>
        public Status SignStatus { get; set; }
        /// <summary>
        /// Người ký
        /// </summary>
        public string? SignBy { get; set; }
        /// <summary>
        /// is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
