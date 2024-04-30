using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Dto
{
    public class RegisterDTO
    {
        [Required, MaxLength(50)]
        public  string FirstName { get; set; }
        [Required, MaxLength(50)]
        public  string LastName { get; set; }
        [Required, MaxLength(50)]
        public  string UserName { get; set; }
        [Required, MaxLength(50)]
        public  string Email { get; set; }
        [Required, MaxLength(50)]
        public  string Password { get; set; }
    }
}
