using DiamondJewelryAPI.API.Models;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Interfaces.Persistence;

public interface IMongoContext
{
    IMongoDatabase Database { get; }
}

public class MongoContext : IMongoContext
{
    public MongoContext(IOptions<DiamondJewelryDBSettings> connectionSetting)
    {
        var client = new MongoClient(connectionSetting.Value.ConnectionString);
        Database = client.GetDatabase(connectionSetting.Value.DatabaseName);
    }

    public IMongoDatabase Database { get; }
}
