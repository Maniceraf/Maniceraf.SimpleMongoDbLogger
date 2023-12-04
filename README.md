# **Maniceraf.SimpleMongoDbLogger - MongoDB Logger for .NET**

**Maniceraf.SimpleMongoDbLogger** is a versatile logging library that seamlessly integrates with MongoDB, providing developers with an efficient means to log messages of various severity levels directly into a MongoDB database.

## **Getting Started**

To begin using **Maniceraf.SimpleMongoDbLogger** start by installing the latest version of the package from [Nuget](https://www.nuget.org/packages/Maniceraf.SimpleMongoDbLogger).

## **Installation**

You can install the **Maniceraf.SimpleMongoDbLogger** via [NuGet](https://www.nuget.org/packages/Maniceraf.SimpleMongoDbLogger). Use the Package Manager Console or the .NET CLI:

```bash
dotnet add package Maniceraf.SimpleMongoDbLogger --version 1.0.1
```

## **Usage**

### **Initialization**
Initialize the logger by providing the MongoDB connection string, database name, and collection name:
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

### **Dependency Injection**
If you prefer using Dependency Injection:

#### **1. Configure the MongoDB connection in your application's Startup.cs or equivalent:**
```csharp
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDBLogger;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // MongoDB configuration
        string connectionString = "...";
        string databaseName = "...";
        string collectionName = "...";

        // Register MongoDBLogger as a service
        services.AddSimpleMongoDbLogger(options =>
        {
            options.ConnectionString = connectionString;
            options.DatabaseName = databaseName;
            options.CollectionName = collectionName;
        });

        // Or register MongoDBLogger with another way
        services.AddSimpleMongoDbLogger(connectionString, databaseName, collectionName);

        // Other service registrations...
    }
}
```
#### **2. Inject the ILogger interface where logging is needed:**
```csharp
using MongoDBLogger;

public class SomeClass
{
    private readonly IMongoDbLogger _logger;

    public SomeClass(IMongoDbLogger logger)
    {
        _logger = logger;
    }

    public void SomeMethod()
    {
        // Log some messages
        logger.WriteLog(LogLevel.Info, "This is an informational message");
        await logger.WriteLogAsync(LogLevel.Info, "This is an informational message");

        // Logging other messages...
    }
}
```

## **License**

This library is licensed under the [MIT](https://github.com/Maniceraf/Maniceraf.SimpleMongoDbLogger/blob/master/LICENSE.txt) License.