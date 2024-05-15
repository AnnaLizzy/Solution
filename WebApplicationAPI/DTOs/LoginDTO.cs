namespace WebApplicationAPI.DTOs
{
    public class LoginDTO
    {
        public int UserBeforeLodingID { get; set; }
        public string? UserName { get;set; }
        public string? Password { get;set; }
        public bool RememberMe { get;set; }
    }
}
