using Microsoft.EntityFrameworkCore;
using RockGym.Database;
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
        private readonly RockDbContext _dbContext;

        public GroupTrainingFeedbackRepository(RockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GroupTrainingFeedback> Create(GroupTrainingFeedback groupTrainingFeedback)
        {
            _dbContext.Add(groupTrainingFeedback);
            await _dbContext.SaveChangesAsync();

            return groupTrainingFeedback;
        }

        public async Task Delete(GroupTrainingFeedback groupTrainingFeedback)
        {
            _dbContext.GroupTrainingFeedbacks.Remove(groupTrainingFeedback);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GroupTrainingFeedback> Get(int Id)
        {
            return await _dbContext.GroupTrainingFeedbacks.FirstOrDefaultAsync(feedback => feedback.Id == Id);
        }

        public async Task<List<GroupTrainingFeedback>> GetAll(int groupTrainingId)
        {
           return await _dbContext.GroupTrainingFeedbacks.Where(feedback => feedback.GroupTrainingId == groupTrainingId).ToListAsync();
        }

        public async Task<GroupTrainingFeedback> Update(GroupTrainingFeedback groupTrainingFeedback)
        {
            _dbContext.GroupTrainingFeedbacks.Update(groupTrainingFeedback);
            await _dbContext.SaveChangesAsync();

            return groupTrainingFeedback;
        }
    }
}

