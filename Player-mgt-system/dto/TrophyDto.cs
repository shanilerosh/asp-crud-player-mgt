using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto
{
    public class TrophyDto
    {
        
        public int TrophyId { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string TrophyName { get; set; }
        
        public List<TrophyMatchDto> TrophyMatchList { get; set; }
        public List<string> ParticipatingTeams { get; set; }
        
    }
}
