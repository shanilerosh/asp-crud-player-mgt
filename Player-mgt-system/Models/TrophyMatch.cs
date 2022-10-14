using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class TrophyMatch
    {
        [Key]
        public int TrophyMatchId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [DisplayName("Match Name")]
        [Required]
        public string MatchName { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Location { get; set; }

        public Trophy Trophy { get; set; }
    }
}
