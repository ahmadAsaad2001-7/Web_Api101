using System.Text.Json.Serialization;

namespace Web_Api101.Models
{
    public class AuthRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
