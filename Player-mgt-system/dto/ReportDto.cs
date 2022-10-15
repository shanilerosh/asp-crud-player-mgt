using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Player_mgt_system.Models;

namespace Player_mgt_system.dto
{
    public class ReportDto
    {
        public List<Trophy>Trophies { get; set; }
        public List<Player>PlayersList { get; set; }
        public List<Owner>Owners { get; set; }
        public List<Team>Teams { get; set; }
    }
}
