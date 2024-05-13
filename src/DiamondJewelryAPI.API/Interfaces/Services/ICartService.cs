using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Models.Common;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface ICartService
{
    Task<ErrorOr<IEnumerable<Cart>>> GetCarts();
    Task<ErrorOr<Cart>> GetCart(string id);
    Task<ErrorOr<IEnumerable<CartItemDetails>>> GetUserCartItemsWithDetails(string userId);
    Task<ErrorOr<Cart>> CreateCart(Cart cart);
    Task<ErrorOr<Cart>> UpdateCart(string id, Cart cart);
    Task<ErrorOr<Cart>> UpdateCartItemQuantity(string userId, CartItem cartItemData);
    Task<ErrorOr<Cart>> RemoveCartItem(string userId, string productId);
    Task<ErrorOr<Cart>> RemoveAllCartItems(string userId);
    Task<ErrorOr<Cart>> AddCartItem(string userId, CartItem cartItem);
    Task<ErrorOr<Deleted>> DeleteCart(string id);
}