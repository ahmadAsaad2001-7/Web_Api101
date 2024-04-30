using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Models
{
    public class TokenRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}