using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCoreAutoMigrator;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OplogDataChartBackend.DataAcess;

namespace OplogDataChartBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost server = BuildWebHost(args);
            var env = server.Services.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
            if (!env.IsProduction())
            {
                using (IServiceScope serviceScope = server.Services.GetService<IServiceScopeFactory>().CreateScope())
                {
                    UserDbContext userDbContext = serviceScope.ServiceProvider.GetService<UserDbContext>();
                    new AutoMigrator(userDbContext)
                        .EnableAutoMigration(false, MigrationModelHashStorageMode.Database, () =>
                        {
                            new SeedInitializer(userDbContext).Seed();
                        });
                }
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:4000")
                .Build();
    }
}
