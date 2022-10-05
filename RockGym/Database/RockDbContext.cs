using Microsoft.EntityFrameworkCore;
using RockGym.Models;

namespace RockGym.Database
{
    public class RockDbContext : DbContext
    {
        public RockDbContext(DbContextOptions<RockDbContext> options)
            : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<GroupTrainingFeedback> GroupTrainingFeedbacks { get; set; }
    }
}
