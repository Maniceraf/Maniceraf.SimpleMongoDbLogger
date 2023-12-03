using Maniceraf.SimpleMongoDbLogger.Enums;
using Maniceraf.SimpleMongoDbLogger.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Maniceraf.SimpleMongoDbLogger.Services
{
    public class MongoDbLogger : IMongoDbLogger
    {
        private readonly IMongoCollection<Log> _logCollection;

        public MongoDbLogger(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _logCollection = database.GetCollection<Log>("Log");
        }

        public MongoDbLogger(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _logCollection = database.GetCollection<Log>(collectionName);
        }

        public MongoDbLogger(IOptions<MongoDbLoggerSettings> settings)
        {
            var connectionString = settings.Value.ConnectionString;
            var databaseName = settings.Value.DatabaseName;
            var collectionName = settings.Value.CollectionName;

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _logCollection = database.GetCollection<Log>(collectionName);
        }

        public void WriteLog(ELogLevel level, string message)
        {
            var log = new Log
            {
                Level = level,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            _logCollection.InsertOne(log);
        }

        public async Task WriteLogAsync(ELogLevel level, string message)
        {
            var log = new Log
            {
                Level = level,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            await _logCollection.InsertOneAsync(log);
        }
    }
}