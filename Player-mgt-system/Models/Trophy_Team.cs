namespace Player_mgt_system.Models;

public class Trophy_Team
{
    public int Id { get; set; }
    
    public int TrophyId { get; set; }
    public Trophy Trophy { get; set; }
    
    public int TeamId { get; set; }
    public Team Team { get; set; }
}