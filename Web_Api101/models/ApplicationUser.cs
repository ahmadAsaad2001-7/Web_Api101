using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Web_Api101.Enums;

namespace Web_Api101.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }
    }
}