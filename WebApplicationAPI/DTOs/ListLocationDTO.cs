namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// Location onduty
    /// </summary>
    public class ListLocationDTO
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }        
        /// <summary>
        /// Ma dia diem
        /// </summary>
        public string? LocationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? LocationAbrevationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? LocationDetailName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsDeleted { get; set; }
    }
}
