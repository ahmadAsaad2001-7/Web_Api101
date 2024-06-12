﻿using System.ComponentModel.DataAnnotations;
using Web_Api101.Enums;

namespace Web_Api101.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}