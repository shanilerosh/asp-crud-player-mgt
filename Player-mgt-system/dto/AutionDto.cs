namespace Player_mgt_system.dto;

public class AutionDto
{
    public ICollection<TrophyDto> TrophyDtos { get; set; }
    
    public ICollection<TeamDto> TeamDtos { get; set; }
}