using EFCoreAutoMigrator;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OplogDataChartBackend.DataAcess;
using OplogDataChartBackend.Entities;

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
                    UserManager<User> userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                    new AutoMigrator(userDbContext)
                        .EnableAutoMigration(false, MigrationModelHashStorageMode.Database, async () =>
                        {
                            var seed = new SeedInitializer(userDbContext, userManager);
                            await seed.Seed();
                        });
                }
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:4000", "http://192.168.1.34:27015")
                .UseUrls("http://localhost:4000")
                .Build();
    }
}
