using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    public class DoorPowerManager
    {
        [Key]
        public int DoorPowerManageID { get; set; }
        public int BGID { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? Position { get; set; }
        public string? BU { get; set; }
        public string? Dept { get; set; }
        public string? Notes { get; set; }
        public string? Picture { get; set; }
        public string? EnglishPicture { get; set; }
        public string? Tel { get; set; }

    }
}
