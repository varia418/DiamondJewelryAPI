using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoContext context) : base(context)
    {
    }
    // public Task<Product> GetProduct(string id)
    // {
    //     return await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    // }

    // public Task<List<Product>> GetProducts()
    // {
    //     return await _productsCollection.Find(_ => true).ToListAsync();
    // }
}