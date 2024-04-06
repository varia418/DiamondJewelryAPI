using DiamondJewelryAPI.API.Models;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Product> _productsCollection;

    public MongoDBService(IOptions<DiamondJewelryDBSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);

        _productsCollection = database.GetCollection<Product>(settings.Value.ProductsCollectionName);
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetProducts()
    {
        List<Product> products = await _productsCollection.Find(_ => true).ToListAsync();
        return products;
    }
}