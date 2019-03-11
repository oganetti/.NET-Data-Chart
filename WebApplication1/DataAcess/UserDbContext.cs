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

        public virtual DbSet<MenuBar> MenuBars { get; set; }
        public virtual DbSet<MenuBarUser> MenuBarUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User

            builder.Entity<User>(user =>
            {

            });

            builder.Entity<MenuBar>(menubar =>
            {
                menubar.HasKey(rc => rc.Id);
            });

            builder.Entity<MenuBarUser>(menubaruser =>
            {
                menubaruser.HasKey(rc => rc.Id);
                menubaruser.Metadata.FindNavigation(nameof(MenuBarUser.User)).SetPropertyAccessMode(PropertyAccessMode.Field);
                menubaruser.Metadata.FindNavigation(nameof(MenuBarUser.MenuBar)).SetPropertyAccessMode(PropertyAccessMode.Field);
                menubaruser.HasKey(x => new { x.MenuBarId, x.UserId });
                menubaruser.HasOne(x => x.MenuBar).WithMany(y => y.MenuBarUsers).HasForeignKey(z => z.MenuBarId);
                menubaruser.HasOne(x => x.User).WithMany(y => y.MenuBarUser).HasForeignKey(z => z.UserId);
            });

            base.OnModelCreating(builder);
        }
    }
}
