using WebApplicationAPI.Models.Enum;

namespace ApiLibrary.ViewModels
{
    public class SignLocationViewModel
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
