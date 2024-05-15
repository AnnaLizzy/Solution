using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    /// <summary>
    /// area region
    /// </summary>
    public class AreaRegion
    {
        /// <summary>
        /// area region id
        /// </summary>
        [Key]
        public int AreaRegionID { get; set; }
        /// <summary>
        /// area id
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// region id
        /// </summary>
        public long RegionID { get; set; }
    }
}
