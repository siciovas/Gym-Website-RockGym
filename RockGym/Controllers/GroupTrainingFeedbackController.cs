using Microsoft.AspNetCore.Mvc;
using RockGym.Models;
using RockGym.Repositories;

namespace RockGym.Controllers
{
    [ApiController]
    [Route("api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/trainingfeedback")]
    public class GroupTrainingFeedbackController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IGroupTrainingRepository _groupTraining;
        private readonly IGroupTrainingFeedbackRepository _groupTrainingFeedback;

        public GroupTrainingFeedbackController(ISubscriptionRepository subscription, IGroupTrainingRepository groupTraining, IGroupTrainingFeedbackRepository groupTrainingFeedback)
        {
            _subscription = subscription;
            _groupTraining = groupTraining;
            _groupTrainingFeedback = groupTrainingFeedback;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupTrainingFeedback>>> GetAll(int subscriptionId, int grouptrainingId)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null)
                return NotFound();

            var feedback = await _groupTrainingFeedback.GetAll(grouptrainingId);

            return Ok(feedback);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTrainingFeedback>> Get(int subscriptionId, int grouptrainingId, int id)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null)
                return NotFound();

            var feedback = await _groupTrainingFeedback.Get(id);

            return Ok(feedback);
        }
        
        [HttpPost]
        public async Task<ActionResult<GroupTrainingFeedback>> Post(int subscriptionId, int grouptrainingId, GroupTrainingFeedback groupTrainingFeedback)
        {
            var subscription = await _subscription.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            var training = await _groupTraining.Get(grouptrainingId);
            if (training == null)
                return NotFound();

            groupTrainingFeedback.GroupTrainingId = grouptrainingId;

            await _groupTrainingFeedback.Create(groupTrainingFeedback);

            return Created($"api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/trainingfeedback/{groupTrainingFeedback.Id}", groupTrainingFeedback);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupTrainingFeedback>> Update(int subscriptionId, int grouptrainingId, GroupTrainingFeedback groupTrainingFeedback, int id)
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

            feedback.Feedback = groupTrainingFeedback.Feedback;

            await _groupTrainingFeedback.Update(feedback);

            return Ok();
        }

        [HttpDelete("{id}")]
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

            await _groupTrainingFeedback.Delete(feedback);

            return NoContent();
        }

    }
}
