using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Dto
{
    public class userRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
