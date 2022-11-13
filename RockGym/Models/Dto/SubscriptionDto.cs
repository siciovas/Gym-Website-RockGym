using System.ComponentModel.DataAnnotations;

namespace RockGym.Models.Dto
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionStarts { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubscriptionEnds { get; set; }
    }
}
