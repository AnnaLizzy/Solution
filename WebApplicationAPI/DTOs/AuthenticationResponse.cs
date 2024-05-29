namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// response from authentication
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// refresh token
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
