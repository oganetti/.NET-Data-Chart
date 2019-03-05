namespace OplogDataChartBackend.DataAcess
{
    public sealed class SeedInitializer
    {
        private readonly UserDbContext _dbContext;

        public SeedInitializer(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
          
        }
    }
}
