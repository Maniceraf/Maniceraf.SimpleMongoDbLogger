# Maniceraf.SimpleMongoDbLogger - MongoDB Logger for .NET

**Maniceraf.SimpleMongoDbLogger** is a versatile logging library that seamlessly integrates with MongoDB, providing developers with an efficient means to log messages of various severity levels directly into a MongoDB database.

## Getting Started

To begin using **Maniceraf.SimpleMongoDbLogger** start by installing the latest version of the package from [Nuget][https://www.nuget.org/packages/Maniceraf.SimpleMongoDbLogger].

## Installation

You can install the **Maniceraf.SimpleMongoDbLogger** via [NuGet](https://www.nuget.org/packages/Maniceraf.SimpleMongoDbLogger). Use the Package Manager Console or the .NET CLI:

```bash
dotnet add package Maniceraf.SimpleMongoDbLogger --version 1.0.0-preview-1
```

## Usage
```csharp
using Maniceraf.SimpleMongoDbLogger;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "...";
        string databaseName = "...";
        string collectionName = "...";

        var logger = new MongoDbLogger(connectionString, databaseName, collectionName);

        // Log some messages
        logger.WriteLog(LogLevel.Info, "This is an informational message");
        logger.WriteLog(LogLevel.Warning, "This is a warning message");
        logger.WriteLog(LogLevel.Error, "This is an error message");

        await logger.WriteLogAsync(LogLevel.Info, "This is an informational message");
        await logger.WriteLogAsync(LogLevel.Warning, "This is a warning message");
        await logger.WriteLogAsync(LogLevel.Error, "This is an error message");
    }
}
```

## License

This library is licensed under the [MIT](https://github.com/Maniceraf/Maniceraf.SimpleMongoDbLogger/blob/master/LICENSE.txt) License.