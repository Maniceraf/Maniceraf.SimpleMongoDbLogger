using Maniceraf.SimpleMongoDbLogger.Enums;

namespace Maniceraf.SimpleMongoDbLogger.Services
{
    public interface IMongoDbLogger
    {
        void WriteLog(ELogLevel level, string message);
        Task WriteLogAsync(ELogLevel level, string message);
    }
}
