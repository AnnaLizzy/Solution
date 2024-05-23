namespace WebApplicationAPI.Models
{
    /// <summary>
    /// employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ID
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// ID Number
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// pass
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// DoB
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// company
        /// </summary>
        public string? Company { get; set; }
        /// <summary>
        /// address
        /// </summary>
        public string? EmpAddress { get; set; }
       
    }
}
