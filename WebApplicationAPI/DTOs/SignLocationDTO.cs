using WebApplicationAPI.Models.Enum;

namespace WebApplicationAPI.DTOs
{
    /// <summary>
    /// Sign location DTO
    /// </summary>
    public class SignLocationDTO
    {
        /// <summary>
        /// Sign User 
        /// </summary>
        public string? SignUser { get; set; }
        /// <summary>
        /// Sign Status 
        /// </summary>
        public Status SignStatus { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string? Notes { get; set; }
    }
}
