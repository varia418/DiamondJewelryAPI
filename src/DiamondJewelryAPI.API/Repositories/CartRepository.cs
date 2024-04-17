using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(IMongoContext context) : base(context)
    {
    }

    public ErrorOr<Cart> GetByUserId(string userId)
    {
        var result = QueryableCollection
            .FirstOrDefault(c => c.UserId == userId);

        if (result is null)
        {
            return Errors.Cart.NotFound(userId);
        }

        return result;
    }
}