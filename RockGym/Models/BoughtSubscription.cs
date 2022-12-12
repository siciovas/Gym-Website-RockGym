using RockGym.Jwt;
using RockGym.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace RockGym.Models
{
    public class BoughtSubscription : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionStarts { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionEnds { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Subscription Subscription { get; set; }
    }
}
