namespace WebApplicationAPI.Models
{
    /// <summary>
    /// gửi mail
    /// </summary>
    public class SendMail
    {
        /// <summary>
        /// gửi đến mail 
        /// </summary>
        public string? To { get; set; }
        /// <summary>
        /// Tiêu đề mail
        /// </summary>
        public string? Subject { get; set; }
        /// <summary>
        /// Nội dung mail
        /// </summary>
        public string? Body { get; set; }
        /// <summary>
        /// Cc
        /// </summary>
        public string? Cc { get; set; }
        /// <summary>
        /// bcc
        /// </summary>
        public string? Bcc { get; set; }

    }
}
