using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    /// <summary>
    /// User
    /// </summary>
    public class UserBeforeLoading
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int UserBeforeLodingID { get; set; }
        /// <summary>
        /// Mã thẻ
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// pass
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is deleted
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// mail 
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
