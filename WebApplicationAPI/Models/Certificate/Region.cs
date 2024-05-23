using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{  
    /// <summary>
    /// Region
    /// </summary>
    public class Region
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public long RegionID { get; set; }
        /// <summary>
        /// Region name
        /// </summary>
        public string? RegionName { get; set; }
    }
}
