using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Models.Common;

using ErrorOr;

using MapsterMapper;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    protected readonly IMongoCollection<Product> productCollection;
    private readonly IMapper _mapper;


    public CartRepository(IMongoContext context, IMapper mapper) : base(context)
    {
        productCollection = context.Database.GetCollection<Product>(typeof(Product).Name.ToLower() + "s");
        _mapper = mapper;
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

    public ErrorOr<IEnumerable<CartItemDetails>> GetCartItemsWithDetails(IEnumerable<CartItem> cartItems)
    {
        var query = from ci in cartItems
                    join p in productCollection.AsQueryable() on ci.ProductId equals p.Id into joined
                    select new CartItemDetails(joined.FirstOrDefault(j => j.Id == ci.ProductId), ci.Quantity);

        return query.ToList();
    }
}