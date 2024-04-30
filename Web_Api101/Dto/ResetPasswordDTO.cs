using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Dto
{
    public class ResetPasswordDTO
    {
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string OTP { get; set; }
        [Required]
        public  string NewPassword { get; set; }

        [Required] 
        public  string ConfirmPassword { get; set; }
    }
}
