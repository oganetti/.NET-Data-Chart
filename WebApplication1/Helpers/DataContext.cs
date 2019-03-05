using Microsoft.EntityFrameworkCore;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}