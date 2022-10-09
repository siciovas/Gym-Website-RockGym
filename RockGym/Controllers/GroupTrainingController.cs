using Microsoft.AspNetCore.Mvc;
using RockGym.Models;
using RockGym.Repositories;

namespace RockGym.Controllers
{
    [ApiController]
    [Route("api/subscription/{subscriptionId}/grouptraining")]
    public class GroupTrainingController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptions;
        private readonly IGroupTrainingRepository _groupTrainings;

        public GroupTrainingController(IGroupTrainingRepository groupTraining, ISubscriptionRepository subscriptions)
        {
            _groupTrainings = groupTraining;
            _subscriptions = subscriptions;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupTraining>>> GetAll(int subscriptionId)
        {
            var sub = await _subscriptions.Get(subscriptionId);

            if (sub == null)
                return NotFound();

            return await _groupTrainings.GetAll(subscriptionId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTraining>> Get(int id, int subscriptionId)
        {
            var sub = await _subscriptions.Get(subscriptionId);
            if (sub == null)
                return NotFound();

            var groupTraining = await _groupTrainings.Get(id);


            return Ok(groupTraining);
        }

        [HttpPost]
        public async Task<ActionResult<GroupTraining>> Post(GroupTraining groupTraining, int subscriptionId)
        {
            var subscription = await _subscriptions.Get(subscriptionId);
            if (subscription == null)
                return NotFound();

            groupTraining.SubscriptionId = subscriptionId;

            await _groupTrainings.Create(groupTraining);

            return Created($"/api/subscription/{subscriptionId}/grouptraining{groupTraining.Id}", groupTraining);
        }

        [HttpPut("id")]
        public async Task<ActionResult<GroupTraining>> Update(GroupTraining groupTraining, int id, int subscriptionId)
        {
            var _subscription = await _groupTrainings.Get(subscriptionId);
            if(_subscription == null)
              return NotFound();


            var _groupTraining = await _groupTrainings.Get(id);
            if (_groupTraining == null)
                return NotFound();

            _groupTraining.Name = groupTraining.Name;
            _groupTraining.Time = groupTraining.Time;
            _groupTraining.Duration = groupTraining.Duration;
            _groupTraining.TrainerName = groupTraining.TrainerName;
            _groupTraining.TrainerSurname = groupTraining.TrainerSurname;
            _groupTraining.TrainerYear = groupTraining.TrainerYear;

            await _groupTrainings.Update(_groupTraining);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupTraining>> Delete(int id)
        {
            var training = await _groupTrainings.Get(id);
            if (training == null)
                return NotFound();

            await _groupTrainings.Delete(training);

            return NoContent();
        }

    }
}
