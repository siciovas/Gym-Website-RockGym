using System.ComponentModel.DataAnnotations;

namespace RockGym.Models.Dto
{
    public class BoughtSubscriptionDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionStarts { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionEnds { get; set; }
        public int SubscriptionId { get; set; }
    }
}
