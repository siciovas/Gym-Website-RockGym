namespace RockGym.Models
{
    public class GroupTraining
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int Duration { get; set;}
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
        public int TrainerYear { get; set; }

    }
}
