using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationAPI.Models.Enum;

namespace WebApplicationAPI.Models
{
    /// <summary>
    /// Tạo địa điểm trực
    /// </summary>
    public class Locations
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListID { get; set; }
        /// <summary>
        /// Location ID
        /// </summary>
        public string? LocationID { get; set; }
        /// <summary>
        /// Nhập tên địa điểm
        /// </summary>
        public string? LocationName { get; set; }
        /// <summary>
        /// select khu vực
        /// </summary>
        public string? Area { get; set; }
        /// <summary>
        /// Nhập tầng
        /// </summary>
        public string? Floors { get; set; }        
        /// <summary>
        /// select vùng
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// chon hướng
        /// </summary>
        public string? Azimuth { get; set; }
        /// <summary>
        /// Loai ca truc
        /// </summary>
        public string? StationType { get; set; }
        /// <summary>
        /// nhap toa nha
        /// </summary>
        public string? Building { get; set; }
        /// <summary>
        /// ghi chu
        /// </summary>
        public string? Other { get; set; }
        /// <summary>
        /// ngay bat dau
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// ngay ket thuc cua dia diem truc
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// true: dia diem da xoa, false: dia diem chua xoa
        /// </summary>
        public bool? IsDeleted { get; set; }       
        /// <summary>
        /// trạng thái
        /// </summary>
        public Status SignStatus { get; set; }
        /// <summary>
        /// Nguoi ky
        /// </summary>
        public string? SignUser { get; set; }
        /// <summary>
        /// Ngay ky
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
        /// Employee no
        /// </summary>
        public string? EmployeeNo { get; set; }
    }
}
/* 
 create table Locations (
    ListID int primary key identity(1,1),
    LocationID nvarchar(200),
    LocationName nvarchar(200),
    Area nvarchar(100),
    Region nvarchar(100),
    Building nvarchar(100),
    Floors nvarchar(100),
    Azimuth nvarchar(100),
    StationType nvarchar(100),
    Other nvarchar(250),
    StartTime datetime,
    EndTime datetime,
    CreateTime datetime2,
    IsDeleted bit,
    UpdateTime datetime2,
    SignStatus int, 
    SignUser nvarchar(100),
    SignDate datetime2,
    EmployeeNo nvarchar(50)
)
 
 */
