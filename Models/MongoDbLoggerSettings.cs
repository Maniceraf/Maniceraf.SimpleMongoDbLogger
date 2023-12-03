﻿namespace Maniceraf.SimpleMongoDbLogger.Models
{
    public class MongoDbLoggerSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
