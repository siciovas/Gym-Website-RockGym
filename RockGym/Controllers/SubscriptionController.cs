using Microsoft.AspNetCore.Mvc;
using RockGym.Models;
using RockGym.Repositories;

namespace RockGym.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptions;

        public SubscriptionController(ISubscriptionRepository subscription)
        {
            _subscriptions = subscription;
        }

        [HttpGet]
        public async Task<List<Subscription>> GetAll()
        {
            return await _subscriptions.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> Get(int id)
        {
            var subscription = await _subscriptions.Get(id);
            if (subscription == null) 
                return NotFound();

            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> Post(Subscription subscription)
        {
            await _subscriptions.Create(subscription);

            return Created($"/api/subscription/{subscription.Id}", subscription);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Subscription>> Update(Subscription subscription, int id)
        {
            var sub = await _subscriptions.Get(id);
            if (sub == null)
                return NotFound();

            sub.Name = subscription.Name;
            sub.Price = subscription.Price;
            sub.SubscriptionStarts = subscription.SubscriptionStarts;
            sub.SubscriptionEnds = subscription.SubscriptionEnds;

            await _subscriptions.Update(sub);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subscription>> Delete(int id)
        {
            var subscription = await _subscriptions.Get(id);
            if (subscription == null)
                return NotFound();

            await _subscriptions.Delete(subscription);

            return NoContent();
        }
    }
}
