namespace WebApplicationAPI.DTOs
{
    public class LocationDTO
    {
        public int ListID { get; set; }
        public string? LocationID { get; set; }
        public string? LocationName { get; set; }
        public string? Area { get; set; }  
        public string? Floors { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string? Region { get; set; }
        public int AreaID { get; set; }
        public int RegionID{ get; set;}
    }
}
