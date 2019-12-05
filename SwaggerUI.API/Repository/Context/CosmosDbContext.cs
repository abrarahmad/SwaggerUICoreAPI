using MongoDB.Driver;
using Persistance.Entities;
using Persistance.Settings;

namespace Persistance.Context
{
    public class CosmosDbContext
    {
        private readonly IMongoDatabase _dbContext;
        public CosmosDbContext(ICosmosDatabaseSettings cosmosDatabaseSettings)
        {
            var client = new MongoClient(cosmosDatabaseSettings.ConnectionString);
            _dbContext = client.GetDatabase(cosmosDatabaseSettings.DatabaseName);

            Customers = _dbContext.GetCollection<Customer>("Customer");
        }
        public IMongoCollection<Customer> Customers { get; private set; }
    }
}
