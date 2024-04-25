


using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
   
    public class Region
    {
        [Key]
        public long RegionID { get; set; }
        public string? RegionName { get; set; }
    }
}
