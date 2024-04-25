using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    public class AreaRegion
    {
        [Key]
        public int AreaRegionID { get; set; }
        public int AreaID { get; set; }
        public long RegionID { get; set; }
    }
}
