using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.ViewModels
{
    public class WorkShiftViewModel
    {
        public int ShiftID { get; set; }
        public string? NameShift { get; set; }
        public string? DescriptionShift { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
