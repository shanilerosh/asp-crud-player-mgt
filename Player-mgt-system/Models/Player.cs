using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class Player
    {
        [Key]
        public int PlayId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [Required]
        public string PlayerName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Speciality { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        public User PlayerUser { get; set; }
    }
}
