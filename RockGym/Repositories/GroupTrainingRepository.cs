using Microsoft.EntityFrameworkCore;
using RockGym.Database;
using RockGym.Models;

namespace RockGym.Repositories
{
    public interface IGroupTrainingRepository
    {
        Task<List<GroupTraining>> GetAll(int subscriptionId);
        Task<GroupTraining> Create(GroupTraining groupTraining);
        Task<GroupTraining> Get(int Id);
        Task<GroupTraining> Update(GroupTraining groupTraining);
        Task Delete(GroupTraining groupTraining);
    }
    public class GroupTrainingRepository : IGroupTrainingRepository
    {
        private readonly RockDbContext _dbContext;

        public GroupTrainingRepository(RockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GroupTraining> Create(GroupTraining groupTraining)
        {
            _dbContext.Add(groupTraining);
            await _dbContext.SaveChangesAsync();

            return groupTraining;
        }

        public async Task Delete(GroupTraining groupTraining)
        {
            _dbContext.GroupTrainings.Remove(groupTraining);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GroupTraining> Get(int Id)
        {
            return await _dbContext.GroupTrainings.FirstOrDefaultAsync(training => training.Id == Id);
        }

        public async Task<List<GroupTraining>> GetAll(int subscriptionId)
        {
            return await _dbContext.GroupTrainings.Where(training => training.SubscriptionId == subscriptionId).ToListAsync();
        }

        public async Task<GroupTraining> Update(GroupTraining groupTraining)
        {
            _dbContext.GroupTrainings.Update(groupTraining);
            await _dbContext.SaveChangesAsync();

            return groupTraining;
        }
    }
}
