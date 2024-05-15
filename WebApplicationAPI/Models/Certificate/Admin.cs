namespace WebApplicationAPI.Models.Certificate
{
    /// <summary>
    /// Admin model
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// Admin ID
        /// </summary>
        public int AdminID { get; set; }
        /// <summary>
        ///  rf Admin Role ID
        /// </summary>
        public int AdminRoleID { get; set; }
        /// <summary>
        /// password
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string? EmployeeNO { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// mail
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// bussiness group ID
        /// </summary>
        public int BGID { get; set; }
        /// <summary>
        /// extension : is phone number
        /// </summary>
        public string? Ext { get; set; }

    }
}
