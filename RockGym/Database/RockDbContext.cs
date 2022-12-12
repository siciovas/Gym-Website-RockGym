using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockGym.Models;
using RockGym.Models.Auth;

namespace RockGym.Database
{
    public class RockDbContext : IdentityDbContext<User>
    {
        public RockDbContext(DbContextOptions<RockDbContext> options)
            : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<GroupTrainingFeedback> GroupTrainingFeedbacks { get; set; }
        public DbSet<BoughtSubscription> BoughtSubscription { get; set; }


    }
}
