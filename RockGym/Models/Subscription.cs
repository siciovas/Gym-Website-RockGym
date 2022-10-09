namespace RockGym.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime SubscriptionStarts { get; set; }
        public DateTime SubscriptionEnds { get; set; }
    }
}
