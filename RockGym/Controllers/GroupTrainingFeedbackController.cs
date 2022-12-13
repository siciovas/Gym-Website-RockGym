using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockGym.Models;
using RockGym.Models.Auth;
using RockGym.Models.Dto;
using RockGym.Models.Dto.Post;
using RockGym.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RockGym.Controllers
{
    [ApiController]
    [Route("api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/trainingfeedback")]
    public class GroupTrainingFeedbackController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IGroupTrainingRepository _groupTraining;
        private readonly IGroupTrainingFeedbackRepository _groupTrainingFeedback;
        private readonly IAuthorizationService _authorizationService;

        public GroupTrainingFeedbackController(ISubscriptionRepository subscription, IGroupTrainingRepository groupTraining, IGroupTrainingFeedbackRepository groupTrainingFeedback, IAuthorizationService authorizationService)
        {
            _subscription = subscription;
            _groupTraining = groupTraining;
            _groupTrainingFeedback = groupTrainingFeedback;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<IEnumerable<GroupTrainingFeedbackDto>>> GetAll(int subscriptionId, int grouptrainingId)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null)
                return NotFound();

            var feedbacks = await _groupTrainingFeedback.GetAll(grouptrainingId);

            return Ok(feedbacks.Select(feedback => new GroupTrainingFeedbackDto
            {
                Id = feedback.Id,
                Feedback = feedback.Feedback
            }));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<GroupTrainingFeedbackDto>> Get(int subscriptionId, int grouptrainingId, int id)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null) return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null) return NotFound();

            var feedback = await _groupTrainingFeedback.Get(id);

            return Ok(new GroupTrainingFeedbackDto
            {
                Id = feedback.Id,
                Feedback = feedback.Feedback
            });
        }
        
        [HttpPost]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<GroupTrainingFeedbackDto>> Post(int subscriptionId, int grouptrainingId, GroupTrainingFeedbackPostDto groupTrainingFeedbackPostDto)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null) return NotFound();

            var newFeedback = new GroupTrainingFeedback
            {
                Feedback = groupTrainingFeedbackPostDto.Feedback,
                GroupTraining = training,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };

            await _groupTrainingFeedback.Create(newFeedback);

            return Created($"api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/trainingfeedback/{newFeedback.Id}", new GroupTrainingFeedbackDto
            {
                Id = newFeedback.Id,
                Feedback = newFeedback.Feedback
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<GroupTrainingFeedbackDto>> Update(int subscriptionId, int grouptrainingId, GroupTrainingFeedbackPostDto groupTrainingFeedbackPostDto, int id)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null) return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null) return NotFound();

            var feedback = await _groupTrainingFeedback.Get(id);
            if (feedback == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, feedback, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            feedback.Feedback = groupTrainingFeedbackPostDto.Feedback;

            await _groupTrainingFeedback.Update(feedback);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.RegisteredUser)]
        public async Task<ActionResult<GroupTrainingFeedback>> Delete(int subscriptionId, int grouptrainingId, int id)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null)
                return NotFound();

            var feedback = await _groupTrainingFeedback.Get(id);
            if (feedback == null)
                return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, feedback, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await _groupTrainingFeedback.Delete(feedback);

            return NoContent();
        }

    }
}
