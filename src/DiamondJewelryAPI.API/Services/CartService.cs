using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<Cart>> CreateCart(Cart cart)
    {
        return await _cartRepository.Create(cart);
    }

    public async Task<ErrorOr<Deleted>> DeleteCart(string id)
    {
        await _cartRepository.Delete(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Cart>> GetCart(string id)
    {
        return await _cartRepository.GetById(id);
    }

    public async Task<ErrorOr<IEnumerable<Cart>>> GetCarts()
    {
        return await _cartRepository.GetAll();
    }

    public async Task<ErrorOr<Cart>> UpdateCart(string id, Cart cart)
    {
        return await _cartRepository.Update(id, cart);
    }
}