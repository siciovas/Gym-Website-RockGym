using System.ComponentModel.DataAnnotations;

namespace RockGym.Models.Auth
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
