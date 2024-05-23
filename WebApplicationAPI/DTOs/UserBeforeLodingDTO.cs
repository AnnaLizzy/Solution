using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// user 
    /// </summary>
    public class UserBeforeLodingDTO
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int UserBeforeLodingID { get; set; }
        /// <summary>
        /// Ma the
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// Ten nhan vie
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// pass hash MD5
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// is delete
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Ngày tạo 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Mã BG
        /// </summary>
        public int BGID { get; set; }
        /// <summary>
        /// Mã chi phí 
        /// </summary>
        public string? BUCode { get; set; }
    }
}
