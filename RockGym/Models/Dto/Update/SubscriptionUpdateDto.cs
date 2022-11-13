using System.ComponentModel.DataAnnotations;

namespace RockGym.Models.Dto.Update
{
    public class SubscriptionUpdateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
