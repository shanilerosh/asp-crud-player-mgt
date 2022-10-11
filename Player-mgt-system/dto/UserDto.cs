using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto
{
    public class UserDto
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }
        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Speciality")]
        public string Speciality { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
