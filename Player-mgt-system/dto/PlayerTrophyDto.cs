using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto;

public class PlayerTrophyDto
{
    //Player Data
    public int PlayId { get; set; }
    public string PlayerName { get; set; }
    public string Country { get; set; }
    public string Speciality { get; set; }
    public string Description { get; set; }
    
    //Trophy Data
    public int TrophyId { get; set; }
    [DisplayName("Trophy Name")]
    public string TrophyName { get; set; }
    [DisplayName("Start Date")]
    public DateTime StartDate { get; set; }
    [DisplayName("End Date")]
    public DateTime EndDate { get; set; }
    [DisplayName("Venue")]
    public string Venue { get; set; }

    public ICollection<TrophyDto> TrophyDtos { get; set; }
    
    public ICollection<TrophyDto> CurrentTrophies { get; set; }
}