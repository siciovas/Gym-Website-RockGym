using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockGym.Models;
using RockGym.Models.Auth;
using RockGym.Models.Dto;
using RockGym.Models.Dto.Post;
using RockGym.Models.Dto.Update;
using RockGym.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RockGym.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptions;
        private readonly IAuthorizationService _authorizationService;

        public SubscriptionController(ISubscriptionRepository subscription, IAuthorizationService authorizationService)
        {
            _subscriptions = subscription;
            _authorizationService = authorizationService;

        }

        [HttpGet]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<IEnumerable<SubscriptionDto>> GetAll()
        {
            var subs = await _subscriptions.GetAll();

            return subs.Select(subs => new SubscriptionDto
            {
                Id = subs.Id,
                Name = subs.Name,
                Price = subs.Price,
                SubscriptionStarts = subs.SubscriptionStarts,
                SubscriptionEnds = subs.SubscriptionEnds
            });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<SubscriptionDto>> Get(int id)
        {
            var subscription = await _subscriptions.Get(id);
            if (subscription == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, subscription, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            return Ok(new SubscriptionDto
            {
                Id=subscription.Id,
                Name=subscription.Name,
                Price=subscription.Price,
                SubscriptionStarts=subscription.SubscriptionStarts,
                SubscriptionEnds=subscription.SubscriptionEnds
            });
        }

        [HttpPost]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<SubscriptionDto>> Post(SubscriptionPostDto subscription)
        {
            var newSub = new Subscription
            {
                Name = subscription.Name,
                Price = subscription.Price,
                SubscriptionStarts = subscription.SubscriptionStarts,
                SubscriptionEnds = subscription.SubscriptionEnds,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };

            await _subscriptions.Create(newSub);

            return Created($"/api/subscription/{newSub.Id}", new SubscriptionDto
            {
                Id = newSub.Id,
                Name = newSub.Name,
                Price = newSub.Price,
                SubscriptionStarts = newSub.SubscriptionStarts,
                SubscriptionEnds = newSub.SubscriptionEnds
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<SubscriptionDto>> Update(SubscriptionUpdateDto subscriptionUpdateDto, int id)
        {
            var sub = await _subscriptions.Get(id); 
            if (sub == null) return NotFound();

            sub.Name = subscriptionUpdateDto.Name;
            sub.Price = subscriptionUpdateDto.Price;


            await _subscriptions.Update(sub);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<Subscription>> Delete(int id)
        {
            var subscription = await _subscriptions.Get(id);
            if (subscription == null) return NotFound();

            await _subscriptions.Delete(subscription);

            return NoContent();
        }
    }
}
