using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Player_mgt_system.dto
{
    public class LoginDto
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        
        public string CustomError { get; set; }
        
        
    }
}
