using MongoDB.Driver;

namespace mongodb_playground
{
    public class DbClient
    {
        // or use a connection string
        private MongoClient _client;
        public MongoClient Client {
            get {
                return _client;
            }
        }

        public IMongoDatabase getDatabase(string db) {
            return _client.GetDatabase(db);
        }

        public IMongoCollection<T> getCollection<T>(string db, string coll) {
            return getDatabase(db).GetCollection<T>(coll);
        }

        public DbClient(string connectionString = "mongodb://localhost:27017") {
            _client = new MongoClient(connectionString);
        }
    }
}
