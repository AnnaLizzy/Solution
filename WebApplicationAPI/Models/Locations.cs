using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    public class Locations
    {
        [Key]       
        public int ListID { get; set; }
        public string? LocationID { get; set; }
        public string? LocationName { get; set; }
        public string? Area { get; set; }
        public string? Floors { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string? Region { get; set; }
    
    }
}
