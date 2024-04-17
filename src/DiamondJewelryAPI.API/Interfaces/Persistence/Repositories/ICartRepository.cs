using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    ErrorOr<Cart> GetByUserId(string userId);
}
