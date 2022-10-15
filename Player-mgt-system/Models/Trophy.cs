using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Player_mgt_system.Models
{
    public class Trophy
    {
        [Key]
        public int TrophyId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [DisplayName("Trophy Name")]
        [Required]
        public string TrophyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Venue { get; set; }
        
        public List<TrophyMatch> TrophyMatchList { get; set; }
        
        
        public List<Player_Trophy> Player_Trophies { get; set; }
    }
}
