namespace WebApplicationApp.Models
{
    public class ShiftDetail
    {
        public int ShiftDetailID { get; set; }
        public int ShiftID { get; set; }
        public int EmployeeID { get; set; }      
        public bool IsDeleted { get; set; }
    }
}
