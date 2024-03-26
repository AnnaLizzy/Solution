namespace WebApplicationAPI.Models.Certificate
{
    public class UserBeforeLoading
    {
        public int UserBeforeLoadingID { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }
        public string? Notes { get; set; }
        public int BGID { get; set; }
        public string? BUCode { get; set; }
    }
}
