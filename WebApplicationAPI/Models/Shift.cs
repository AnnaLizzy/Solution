namespace WebApplicationAPI.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateTime DateWork { get; set; }
    }
}
