using RockGym.Database;
using RockGym.Models;

namespace RockGym.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GeAll();
        Task<Subscription> Create(Subscription subscription);
        Task<Subscription> Get(int Id);
        Task<Subscription> Update(Subscription subscription);
        Task Delete(int Id);
    }
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly RockDbContext _dbContext;

        public SubscriptionRepository(RockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Subscription> Create(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscription>> GeAll()
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
