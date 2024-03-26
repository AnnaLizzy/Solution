using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.ViewModels
{
    public class CreateWorkScheduleViewModel
    {
        public int SchedulesID { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int ShiftID { get; set; }
        public string? ShiftName { get; set; }
        public string? LocationID { get; set; }
        public string? LocationName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
          
        public int AreaID { get; set; }
      
        public string? NameShift { get; set; }
        public string? DescriptionShift { get; set; }
        public List<ListLocationVM>? LocationVM { get; set; }
    }
}
