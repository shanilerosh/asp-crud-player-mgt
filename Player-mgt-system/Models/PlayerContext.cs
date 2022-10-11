using Microsoft.EntityFrameworkCore;

namespace Player_mgt_system.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) {
            
        }

        public DbSet<Player> players{ get; set; }

        public DbSet<User> Users{ get; set; }
    }
}
