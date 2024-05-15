using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    /// <summary>
    /// Door Power Manager
    /// </summary>
    public class DoorPowerManager
    {
        /// <summary>
        /// Door Power Manager ID
        /// </summary>
        [Key]
        public int DoorPowerManageID { get; set; }
        /// <summary>
        /// business group ID
        /// </summary>
        public int BGID { get; set; }
        /// <summary>
        /// employee ID
        /// </summary>
        public string? EmployeeNo { get; set; }
        /// <summary>
        /// employee name
        /// </summary>
        public string? EmployeeName { get; set; }
        /// <summary>
        /// position
        /// </summary>
        public string? Position { get; set; }
        /// <summary>
        /// business unit
        /// </summary>
        public string? BU { get; set; }
        /// <summary>
        /// department
        /// </summary>
        public string? Dept { get; set; }
        /// <summary>
        /// mail
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// picture
        /// </summary>
        public string? Picture { get; set; }
        /// <summary>
        /// English picture
        /// </summary>
        public string? EnglishPicture { get; set; }
        /// <summary>
        /// phone number
        /// </summary>
        public string? Tel { get; set; }

    }
}
