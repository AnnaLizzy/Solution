using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAPI.Models.Enum;

namespace ApiLibrary.ViewModels
{
    public class CreateWorkScheduleViewModel
    {       
        public int EmployeeID { get; set; }   
        public int ShiftID { get; set; }     
        public string? LocationID { get; set; }       
        public string? BG { get; set; }
        public string? BU { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BuCode { get; set; }
        public string? Notes { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        public string? Frequency { get; set; }
        public int Interval { get; set; }        
        public string[]? ByWeekday { get; set; }   
        public int SignBy { get; set; }
        public List<ListLocationVM>? LocationVM { get; set; }
    }
}
