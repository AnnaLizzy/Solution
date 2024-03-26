namespace WebApplicationAPI.Models.Certificate

{
    public class Area
    {
        public int AreaID { get; set; }
        public string? AreaName { get; set; }
        public string? AreaMeno { get; set; }
        public string? ShortName { get; set; }
        public int ListIndex { get; set; }
        public string? FullName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
