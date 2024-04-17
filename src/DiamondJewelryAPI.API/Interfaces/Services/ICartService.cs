using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface ICartService
{
    Task<ErrorOr<IEnumerable<Cart>>> GetCarts();
    Task<ErrorOr<Cart>> GetCart(string id);
    Task<ErrorOr<Cart>> CreateCart(Cart cart);
    Task<ErrorOr<Cart>> UpdateCart(string id, Cart cart);
    Task<ErrorOr<Deleted>> DeleteCart(string id);
}