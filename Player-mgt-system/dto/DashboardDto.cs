using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto
{
    public class DashboardDto
    {
        public int TeamCount { get; set; }
        public int PlayerCount { get; set; }
        public int TrophyCount { get; set; }
        public int OwnerCount { get; set; }

    }
}
