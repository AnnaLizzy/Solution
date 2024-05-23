
using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.ViewModels
{
   public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string? EmployeeNo { get; set; }
        public string? Password { get; set; }
        public string? EmployeeName { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
        public string? Company { get; set; }
        public string? EmpAddress { get; set; }
    }
}
