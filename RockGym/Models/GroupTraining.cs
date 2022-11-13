using RockGym.Jwt;
using RockGym.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace RockGym.Models
{
    public class GroupTraining : IUserOwnedResource
    {
        public int Id { get; set; }
        public Subscription Subscription { get; set; }
        public string Name { get; set; }
        public string Starts { get; set; }
        public int Duration { get; set;}
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
        public int TrainerYear { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
