using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Column(TypeName="nvarchar(250)")]
        [Required]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string role { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string AuthStatus { get; set; }

    }
}
