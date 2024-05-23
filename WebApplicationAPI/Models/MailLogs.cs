namespace WebApplicationAPI.Models
{
    /// <summary>
    /// Mail log
    /// </summary>
    public class MailLogs
    {
        /// <summary>
        /// Mail log ID
        /// </summary>
        public int MailLogsID { get; set; }
        /// <summary>
        /// Subject
        /// </summary>
        public string? MailSubject { get; set; }
        /// <summary>
        /// body
        /// </summary>
        public string? MailBody { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public string? MailStatus { get; set; }
        /// <summary>
        /// sent time
        /// </summary>
        public DateTime SendTime{ get; set; }
    }
}
