namespace WebApplicationAPI.Models.Certificate

{
    /// <summary>
    /// Area model
    /// </summary>
    public class Area
    {
        /// <summary>
        /// area id
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// area name
        /// </summary>
        public string? AreaName { get; set; }
        /// <summary>
        /// area meno
        /// </summary>
        public string? AreaMeno { get; set; }
        /// <summary>
        /// short name
        /// </summary>
        public string? ShortName { get; set; }
        /// <summary>
        /// list index
        /// </summary>
        public int ListIndex { get; set; }
        /// <summary>
        /// full name
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        /// is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
