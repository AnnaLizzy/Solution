using System.ComponentModel.DataAnnotations;

namespace WebApplicationApp.ViewModels
{
    public class RegisterRequest
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee No is required")]
        public string? EmployeeNo { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? EmployeeName { get; set; }
        public string? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }

        public string? Company { get; set; }
    }
}
