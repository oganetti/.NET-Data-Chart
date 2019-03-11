using Microsoft.AspNetCore.Identity;
using OplogDataChartBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OplogDataChartBackend.DataAcess
{
    public sealed class SeedInitializer
    {
        private readonly UserDbContext _dbContext;
        private readonly UserManager<User> _userManager = null;

        public SeedInitializer(UserDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void Seed()
        {        
                
            var user = new User(
                       "Ogan",
                       "Dragonetti",
                       null,
                       "oganetti"
                       );

            _userManager.CreateAsync(user, "QWEqwe.1");

            var user2 = new User(
                       "Ogan",
                       "Dragonetti",
                       null,
                       "oganetti2"
                       );

            _userManager.CreateAsync(user, "QWEqwe.1");
            _userManager.CreateAsync(user2, "QWEqwe.1");

            Task<string> userId = _userManager.GetUserIdAsync(user);
            Task<string> userId2 = _userManager.GetUserIdAsync(user2);


            IEnumerable<MenuBar> menubars = MenuBarGenerator.Entities().ToList();
            _dbContext.MenuBars.AddRange(menubars);
            _dbContext.SaveChanges();

            IEnumerable<MenuBarUser> menubarsuser = MenuBarUserGenerator.Entities(userId.Result, menubars,0).ToList();
            _dbContext.MenuBarUsers.AddRange(menubarsuser);
            IEnumerable<MenuBarUser> menubarsuser2 = MenuBarUserGenerator.Entities(userId2.Result, menubars, 1).ToList();
            _dbContext.MenuBarUsers.AddRange(menubarsuser2);
            _dbContext.SaveChanges();





        }
    }
}
