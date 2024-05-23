namespace WebApplicationAPI.ViewModels
{
    /// <summary>
    /// Represents an employee view model.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        public string? EmployeeNo { get; set; }

        /// <summary>
        /// Gets or sets the employee password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the employee gender.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the employee phone number.
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string? Company { get; set; }
    }
}
