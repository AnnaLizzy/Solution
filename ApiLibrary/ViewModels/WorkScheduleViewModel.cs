using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.ViewModels
{
    public class WorkScheduleViewModel
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
    }
}
