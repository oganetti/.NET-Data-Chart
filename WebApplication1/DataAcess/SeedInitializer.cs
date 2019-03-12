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
        private readonly UserManager<User> _userManager;

        public SeedInitializer(UserDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task Seed()
        {

            var user = new User(
                       "Ogan",
                       "Dragonetti",
                       "a@a.com",
                       "oganetti"
                       );

            var user2 = new User(
                       "Ogan",
                       "Dragonetti",
                       "a@a222.com",
                       "oganetti2"
                       );



            //_userManager.PasswordHasher.HashPassword(user, "QWEqwe.1");
            //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, "QWEqwe.1");
            //_userManager.PasswordHasher.VerifyHashedPassword(user,user.PasswordHash, "QWEqwe.1");
            //await _dbContext.Users.AddAsync(user);


            //user2.PasswordHash = _userManager.PasswordHasher.HashPassword(user2, "QWEqwe.1");
            //await _dbContext.Users.AddAsync(user2);



            _userManager.CreateAsync(user, "QWEqwe.1").Wait();
            _userManager.CreateAsync(user2, "QWEqwe.1").Wait();

            var userId = await _userManager.GetUserIdAsync(user);
            var userId2 = await _userManager.GetUserIdAsync(user2);


            IEnumerable<MenuBar> menubars = MenuBarGenerator.Entities().ToList();
            _dbContext.MenuBars.AddRange(menubars);
            _dbContext.SaveChanges();

            IEnumerable<MenuBarUser> menubarsuser = MenuBarUserGenerator.Entities(userId, menubars, 0).ToList();
            _dbContext.MenuBarUsers.AddRange(menubarsuser);
            IEnumerable<MenuBarUser> menubarsuser2 = MenuBarUserGenerator.Entities(userId2, menubars, 1).ToList();
            _dbContext.MenuBarUsers.AddRange(menubarsuser2);
            _dbContext.SaveChanges();
        }
    }
}
