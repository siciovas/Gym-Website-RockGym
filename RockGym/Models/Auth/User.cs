using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RockGym.Models.Auth
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PersonalNumber { get; set; } = string.Empty;
    }
}
