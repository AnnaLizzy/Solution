using System.ComponentModel.DataAnnotations;
using WebApplicationAPI.Models.Enum;

namespace ApiLibrary.ViewModels
{
    public class ListLocationVM
    {
        
        public int ListID { get; set; }
        public string? LocationID { get; set; }
        [Required(ErrorMessage ="Please enter location name")]
        public string? LocationName { get; set; }
        public string? Floors { get; set; }
        public string? Area { get; set; }
        public string? Region { get; set; }
        public string? Azimuth { get; set; }
        public string? Building { get; set; }
        public string? StationType { get; set; }
        public string? Other { get; set; }
        [Required(ErrorMessage = "Please enter start time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }
        [Required(ErrorMessage = "Please enter end time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        public Status SignStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        [Required(ErrorMessage = "Please enter sign user")]
        public string? SignUser { get; set; }
        public string? EmployeeNo { get; set; }

    }
}
