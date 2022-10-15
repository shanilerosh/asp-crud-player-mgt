namespace Player_mgt_system.Models;

public class Player_Trophy
{
    public int Id { get; set; }
    
    public int TrophyId { get; set; }
    public Trophy Trophy { get; set; }
    
    public int PlayerID { get; set; }
    public Player Player { get; set; }
}