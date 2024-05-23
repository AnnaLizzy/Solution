namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// Nhan Vien 
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// Mã thẻ nhân viên
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// password
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// company
        /// </summary>
        public string? Company { get; set; }
        /// <summary>
        /// Dia chi
        /// </summary>
        public string? EmpAddress { get; set; }
       
    }
}
