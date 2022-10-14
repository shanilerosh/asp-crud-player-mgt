using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto
{
    public class TrophyMatchDto
    {
        [Required]
        public string MatchName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
       
        
    }
}
