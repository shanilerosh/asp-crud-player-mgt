using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [DisplayName("Team Name")]
        [Required]
        public string TeamName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string TeamOwner { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string TeamState { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        public decimal MaxPrice { get; set; }

        public ICollection<Player> Players;
    }
}
