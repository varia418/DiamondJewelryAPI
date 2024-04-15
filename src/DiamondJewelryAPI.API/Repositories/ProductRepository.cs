using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoContext context) : base(context)
    {
    }

    public ErrorOr<IEnumerable<string>> GetAllTitles()
    {
        var query = QueryableCollection
            .Select(p => p.Title);

        var result = query.ToList();
        return result;
    }
}