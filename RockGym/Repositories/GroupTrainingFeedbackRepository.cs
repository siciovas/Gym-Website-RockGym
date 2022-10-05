using RockGym.Models;

namespace RockGym.Repositories
{
    public interface IGroupTrainingFeedbackRepository
    {
        Task<List<GroupTrainingFeedback>> GetAll(int groupTrainingId);
        Task<GroupTrainingFeedback> Create(GroupTrainingFeedback groupTrainingFeedback);
        Task<GroupTrainingFeedback> Get(int Id);
        Task<GroupTrainingFeedback> Update(GroupTrainingFeedback groupTrainingFeedback);
        Task Delete(GroupTrainingFeedback groupTrainingFeedback);
    }
    public class GroupTrainingFeedbackRepository : IGroupTrainingFeedbackRepository
    {
        public Task<GroupTrainingFeedback> Create(GroupTrainingFeedback groupTrainingFeedback)
        {
            throw new NotImplementedException();
        }

        public Task Delete(GroupTrainingFeedback groupTrainingFeedback)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTrainingFeedback> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupTrainingFeedback>> GetAll(int groupTrainingId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTrainingFeedback> Update(GroupTrainingFeedback groupTrainingFeedback)
        {
            throw new NotImplementedException();
        }
    }
}

