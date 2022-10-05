﻿using Microsoft.EntityFrameworkCore;
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
        Task Delete(Subscription subscription);
    }
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly RockDbContext _dbContext;

        public SubscriptionRepository(RockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subscription> Create(Subscription subscription)
        {
            _dbContext.Add(subscription);
            await _dbContext.SaveChangesAsync();

            return subscription;
        }

        public async Task Delete(Subscription subscription)
        {
            _dbContext.Subscriptions.Remove(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Subscription>> GeAll()
        {
            return await _dbContext.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> Get(int Id)
        {
            return await _dbContext.Subscriptions.FirstOrDefaultAsync(subscription => subscription.Id == Id);
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _dbContext.Subscriptions.Update(subscription);
            await _dbContext.SaveChangesAsync();

            return subscription;
        }
    }
}
