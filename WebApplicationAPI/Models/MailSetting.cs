namespace WebApplicationAPI.Models
{
    /// <summary>
    /// mail setting
    /// </summary>
    public class MailSetting
    {
        /// <summary>
        /// Mail
        /// </summary>
        public string? Mail { get; set; }
        /// <summary>
        /// display name
        /// </summary>
        public string? DisplayName { get; set; }
        /// <summary>
        /// Pass
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// SmtpServer
        /// </summary>
        public string? SmtpServer { get; set; }
        /// <summary>
        /// SmtpPort
        /// </summary>
        public int SmtpPort { get; set; }
    }
}
