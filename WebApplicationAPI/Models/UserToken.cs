using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpiryDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
