using RockGym.Models;

namespace RockGym.Repositories
{
    public interface IGroupTrainingRepository
    {
        Task<List<GroupTraining>> GetAll(int subscriptionId);
        Task<GroupTraining> Create(GroupTraining groupTraining);
        Task<GroupTraining> Get(int Id);
        Task<GroupTraining> Update(GroupTraining groupTraining);
        Task Delete(int Id);
    }
    public class GroupTrainingRepository : IGroupTrainingRepository
    {
        public Task<GroupTraining> Create(GroupTraining groupTraining)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTraining> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupTraining>> GetAll(int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTraining> Update(GroupTraining groupTraining)
        {
            throw new NotImplementedException();
        }
    }
}
