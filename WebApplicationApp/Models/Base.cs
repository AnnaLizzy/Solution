namespace WebApplicationApp.Models
{
    public class Base
    {
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
