using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.Certificate
{
    /// <summary>
    /// list locations
    /// </summary>
    public class OndutyListLocations
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// location id
        /// </summary>
        public string? LocationID { get; set; }
        /// <summary>
        /// location name
        /// </summary>
        public string? LocationAbrevationName { get; set; }
        /// <summary>
        /// location detail name
        /// </summary>
        public string? LocationDetailName { get; set; }
        /// <summary>
        /// area id
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// x 
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// y
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// is deleted
        /// </summary>
        public int IsDeleted { get; set; }

    }
}
