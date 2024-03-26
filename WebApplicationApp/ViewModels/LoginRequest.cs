using System.ComponentModel.DataAnnotations;

namespace WebApplicationApp.ViewModels
{
    public class LoginRequest
    {
       
        [Required(ErrorMessage = "Employee No is required")]
        public string? EmployeeNo { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
 
    }
}
