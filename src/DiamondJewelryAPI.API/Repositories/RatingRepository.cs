using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Repositories;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(IMongoContext context) : base(context)
    {
    }

    public ErrorOr<IEnumerable<Rating>> GetByProductId(string productId)
    {
        return QueryableCollection
            .Where(x => x.ProductId == productId).ToList();
    }
}