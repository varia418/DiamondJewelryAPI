using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Repositories;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(IMongoContext context) : base(context)
    {
    }
}