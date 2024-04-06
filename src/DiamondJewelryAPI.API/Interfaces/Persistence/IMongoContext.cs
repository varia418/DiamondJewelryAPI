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
    public MongoContext(IDiamondJewelryDBSettings connectionSetting)
    {
        var client = new MongoClient(connectionSetting.ConnectionString);
        Database = client.GetDatabase(connectionSetting.DatabaseName);
    }

    public IMongoDatabase Database { get; }
}
