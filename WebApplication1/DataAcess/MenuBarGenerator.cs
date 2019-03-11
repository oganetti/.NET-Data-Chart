using System;
using System.Collections.Generic;
using Bogus;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.DataAcess
{
    public static class MenuBarGenerator
    {
        public static IEnumerable<MenuBar> Entities()
        {
            return new Faker<MenuBar>()
                .CustomInstantiator(fake =>
                {
                    return new MenuBar(
                        Guid.NewGuid(), fake.Name.JobArea(), null, "sql", "select * from hour", "Server=.\\SQLEXPRESS;Database=test3;Trusted_Connection=True;MultipleActiveResultSets=true");

                })
                .Generate(5);
        }
    }
}
