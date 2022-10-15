using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;

namespace Player_mgt_system.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player_Trophy>()
                .HasOne(b => b.Player)
                .WithMany(pl => pl.Player_Trophies)
                .HasForeignKey(pl => pl.PlayerID);
            
            modelBuilder.Entity<Player_Trophy>()
                .HasOne(b => b.Trophy)
                .WithMany(pl => pl.Player_Trophies)
                .HasForeignKey(pl => pl.TrophyId);
        }

        public DbSet<Player> players{ get; set; }

        public DbSet<User> Users{ get; set; }

        public DbSet<Player_mgt_system.Models.Team>? Team { get; set; }

        public DbSet<Player_mgt_system.Models.Trophy>? Trophy { get; set; }
        
        public DbSet<Player_mgt_system.Models.TrophyMatch>? TrophyMatch { get; set; }
        
        public DbSet<Player_mgt_system.Models.Player_Trophy>? PlayerTrophies { get; set; }
        
    }
}
