using WebApplicationAPI.Models.Enum;

namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// data transfer object cho location
    /// </summary>
    public class LocationDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ListID { get; set; }
        /// <summary>
        /// mã địa điểm trực
        /// </summary>
        public string? LocationID { get; set; }
        /// <summary>
        /// Tên địa điểm
        /// </summary>
        public string? LocationName { get; set; }
        /// <summary>
        /// khu vực
        /// </summary>
        public string? Area { get; set; }
        /// <summary>
        /// Tầng
        /// </summary>
        public string? Floors { get; set; }        
        /// <summary>
        /// vùng
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Mã khu vực 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// Mã vùng
        /// </summary>
        public long RegionID{ get; set;}
        /// <summary>
        /// Huong
        /// </summary>
        public string? Azimuth { get; set; }
        /// <summary>
        /// Loại ca trực
        /// </summary>
        public string? StationType { get; set; }
        /// <summary>
        /// toa nha
        /// </summary>
        public string? Building { get; set; }
        /// <summary>
        /// ghi chu khac
        /// </summary>
        public string? Other { get; set; }
        /// <summary>
        /// Ngay bat dau
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Ngay ket thuc
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// trang thai ky
        /// </summary>
        public Status SignStatus { get; set; }
        /// <summary>
        /// ten nguoi ky
        /// </summary>
        public string? SignUser { get; set; }
        /// <summary>
        /// ma nguoi ky
        /// </summary>
        public string? SignUserID { get; set; }
        /// <summary>
        /// ngay ky
        /// </summary>
        public DateTime SignDate { get; set; }
        /// <summary>
        /// ngay cap nhat
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// ngay tao
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Employee No
        /// </summary>
        public string? EmployeeNo { get; set; }
    }
}
