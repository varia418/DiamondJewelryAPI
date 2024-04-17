using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(IMongoContext context) : base(context)
    {
    }
}