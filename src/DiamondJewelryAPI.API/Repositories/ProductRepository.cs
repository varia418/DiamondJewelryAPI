using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoContext context) : base(context)
    {
    }
}