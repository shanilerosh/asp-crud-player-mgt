using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;

namespace Player_mgt_system.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) {
            
        }

        public DbSet<Player> players{ get; set; }

        public DbSet<User> Users{ get; set; }

        public DbSet<Player_mgt_system.Models.Team>? Team { get; set; }

        public DbSet<Player_mgt_system.Models.Trophy>? Trophy { get; set; }
        
        public DbSet<Player_mgt_system.Models.TrophyMatch>? TrophyMatch { get; set; }
    }
}
