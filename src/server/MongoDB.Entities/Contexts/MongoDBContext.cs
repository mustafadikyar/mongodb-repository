using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Utilities;

namespace MongoDB.Entities.Contexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IOptions<MongoSettings> setting)
        {
            MongoClient client = new(setting.Value.ConnectionString);
            _database = client.GetDatabase(setting.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name.Trim());
        public IMongoDatabase GetDatabase => _database;
    }
}
