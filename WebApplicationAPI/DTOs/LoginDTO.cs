namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// User
        /// </summary>
        public string? UserName { get;set; }
        /// <summary>
        /// pass
        /// </summary>
        public string? Password { get;set; }
        /// <summary>
        /// remember
        /// </summary>
        public bool RememberMe { get;set; }
    }
}
