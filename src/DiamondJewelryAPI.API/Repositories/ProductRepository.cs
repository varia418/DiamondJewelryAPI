using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    protected readonly IQueryable<Product> QueryableCollection;
    public ProductRepository(IMongoContext context) : base(context)
    {
        QueryableCollection = DbSet.AsQueryable();
    }

    public ErrorOr<IEnumerable<string>> GetAllTitles()
    {
        var query = QueryableCollection
            .Select(p => p.Title);

        var result = query.ToList();

        // var builder = Builders<Product>.Projection;
        // var projection = builder.Include(product => product.Title);

        // var all = await DbSet.FindAsync(Builders<Product>.Filter.Empty, projection);
        return result;
    }
}