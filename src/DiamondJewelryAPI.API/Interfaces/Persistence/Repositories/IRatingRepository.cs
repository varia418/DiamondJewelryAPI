using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;

public interface IRatingRepository : IRepository<Rating>
{
    ErrorOr<IEnumerable<Rating>> GetByProductId(string productId);
}
