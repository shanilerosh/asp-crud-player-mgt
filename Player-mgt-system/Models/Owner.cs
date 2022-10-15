using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [Required]
        public string OwnerName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(250)")]
      
        public User OwnerUser { get; set; }

    }
}
