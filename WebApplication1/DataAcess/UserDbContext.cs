using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.DataAcess
{
    public class UserDbContext : IdentityDbContext<User>
    {
 

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
            Database.AutoTransactionsEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User
            builder.Entity<User>(user =>
            {
            });

            base.OnModelCreating(builder);
        }
    }
}
