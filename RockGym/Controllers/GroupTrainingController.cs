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
    [Route("api/subscription/{subscriptionId}/grouptraining")]
    public class GroupTrainingController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptions;
        private readonly IGroupTrainingRepository _groupTrainings;
        private readonly IAuthorizationService _authorizationService;


        public GroupTrainingController(IGroupTrainingRepository groupTraining, ISubscriptionRepository subscriptions, IAuthorizationService authorizationService)
        {
            _groupTrainings = groupTraining;
            _subscriptions = subscriptions;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<IEnumerable<GroupTrainingDto>>> GetAll(int subscriptionId)
        {
            var sub = await _subscriptions.Get(subscriptionId);
            if (sub == null) return NotFound();

            var trainings = await _groupTrainings.GetAll(subscriptionId);

            return Ok(trainings.Select(training => new GroupTrainingDto
            {
                Id = training.Id,
                Name = training.Name,
                Starts = training.Starts,
                Duration = training.Duration,
                TrainerName = training.TrainerName,
                TrainerSurname = training.TrainerSurname,
                TrainerYear = training.TrainerYear
            }));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<GroupTrainingDto>> Get(int id, int subscriptionId)
        {
            var sub = await _subscriptions.Get(subscriptionId);
            if (sub == null) return NotFound();

            var groupTraining = await _groupTrainings.Get(id);
            if (groupTraining == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, groupTraining, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return Forbid();
            }


            return Ok(new GroupTrainingDto
            {
                Id = groupTraining.Id,
                Name = groupTraining.Name,
                Starts = groupTraining.Starts,
                Duration = groupTraining.Duration,
                TrainerName = groupTraining.TrainerName,
                TrainerSurname = groupTraining.TrainerSurname,
                TrainerYear = groupTraining.TrainerYear

            });
        }

        [HttpPost]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<GroupTrainingDto>> Post(GroupTrainingPostDto groupTrainingDto, int subscriptionId)
        {
            var subscription = await _subscriptions.Get(subscriptionId);
            if (subscription == null) return NotFound();

            var training = new GroupTraining
            {
                Name = groupTrainingDto.Name,
                Starts = groupTrainingDto.Starts,
                Duration = groupTrainingDto.Duration,
                TrainerName = groupTrainingDto.TrainerName,
                TrainerSurname = groupTrainingDto.TrainerSurname,
                TrainerYear = groupTrainingDto.TrainerYear,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub),
                Subscription = subscription
            };

            await _groupTrainings.Create(training);

            return Created($"/api/subscription/{subscriptionId}/grouptraining{training.Id}", new GroupTrainingDto
            {
                Id = training.Id,
                Name = training.Name,
                Starts = training.Starts,
                Duration = training.Duration,
                TrainerName = training.TrainerName,
                TrainerSurname = training.TrainerSurname,
                TrainerYear = training.TrainerYear
            });
        }

        [HttpPut("id")]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<GroupTrainingDto>> Update(GroupTrainingUpdateDto groupTrainingDto, int id, int subscriptionId)
        {
            var sub = await _groupTrainings.Get(subscriptionId);
            if(sub == null)
              return NotFound();


            var training = await _groupTrainings.Get(id);
            if (training == null)
                return NotFound();

            training.Name = groupTrainingDto.Name;
            training.Starts = groupTrainingDto.Starts;
            training.Duration = groupTrainingDto.Duration;
            training.TrainerName = groupTrainingDto.TrainerName;
            training.TrainerSurname = groupTrainingDto.TrainerSurname;
            training.TrainerYear = groupTrainingDto.TrainerYear;

            await _groupTrainings.Update(training);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.AdminUser)]
        public async Task<ActionResult<GroupTraining>> Delete(int id, int subscriptionId)
        {
            var sub = await _subscriptions.Get(subscriptionId);
            if (sub == null) return NotFound();
            
            var training = await _groupTrainings.Get(id);
            if (training == null) return NotFound();

            await _groupTrainings.Delete(training);

            return NoContent();
        }
    }
}
