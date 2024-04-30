using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Dto
{
    public class LoginDTO
    {
        [Required]
        public  string UserName { get; set; }
        [Required]
        public  string Password { get; set; }
    }
}
