using RockGym.Jwt;
using RockGym.Models.Auth;

namespace RockGym.Models
{
    public class GroupTrainingFeedback : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public GroupTraining GroupTraining { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
