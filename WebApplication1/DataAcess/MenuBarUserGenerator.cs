using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.DataAcess
{
    public static class MenuBarUserGenerator
    {
        public static IEnumerable<MenuBarUser> Entities(string userId, IEnumerable<MenuBar> menuBarToAssign, int i)
        {
            return new Faker<MenuBarUser>()
                .CustomInstantiator(fake =>
                {
                    return new MenuBarUser(
                        Guid.NewGuid(), userId, menuBarToAssign.ElementAt(i).Id);

                })
                .Generate(1);
        }
    }
}
