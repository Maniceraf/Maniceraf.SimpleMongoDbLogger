using Maniceraf.SimpleMongoDbLogger.Enums;
using MongoDB.Bson;

namespace Maniceraf.SimpleMongoDbLogger.Models
{
    public class Log
    {
        public ObjectId Id { get; set; }
        public ELogLevel Level { get; set; }
        public string Message { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
