using System.ComponentModel.DataAnnotations;

namespace Web_Api101.Dto
{
    public class EmailDTO
    {
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string Subject { get; set; }
        [Required]
        public  string Body { get; set; }
        
        public IList<IFormFile>? Attachements { get; set; }
    }
}
