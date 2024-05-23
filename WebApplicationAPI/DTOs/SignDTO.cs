﻿namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// log sign user
    /// </summary>
    public class SignDTO
    {
        /// <summary>
        /// id
        /// </summary>
        public int SignID { get; set; }
        /// <summary>
        /// sign user
        /// </summary>
        public string? SignUser { get; set; }
        /// <summary>
        /// mail
        /// </summary>
        public string? EMail { get; set; }
        /// <summary>
        /// body
        /// </summary>
        public string? Body { get; set; }
        /// <summary>
        /// subject
        /// </summary>
        public string? SignSubject { get; set; }
        /// <summary>
        /// sign status
        /// </summary>
        public string? SignStatus { get; set; }
        /// <summary>
        /// notes
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// list id
        /// </summary>
        public int ListID { get; set; }
    }
}
