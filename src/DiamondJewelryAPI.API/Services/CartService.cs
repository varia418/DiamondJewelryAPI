using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Models.Common;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public CartService(ICartRepository cartRepository, IUserRepository userRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Cart>> AddCartItem(string userId, CartItem cartItem)
    {
        var getUserResult = await _userRepository.GetById(userId);
        if (getUserResult.IsError) return getUserResult.Errors;

        var getUserCartResult = _cartRepository.GetByUserId(userId);
        if (getUserCartResult.IsError) return getUserCartResult.Errors;

        var cart = getUserCartResult.Value;
        cart.Items.Add(cartItem);
        return await _cartRepository.Update(cart.Id!, cart);
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

    public async Task<ErrorOr<IEnumerable<CartItemDetails>>> GetUserCartItemsWithDetails(string userId)
    {
        var getUserResult = await _userRepository.GetById(userId);
        if (getUserResult.IsError) return getUserResult.Errors;

        var getUserCartResult = _cartRepository.GetByUserId(userId);
        if (getUserCartResult.IsError) return getUserCartResult.Errors;

        var cartItems = getUserCartResult.Value.Items;
        var getCartItemsDetailsResult = _cartRepository.GetCartItemsWithDetails(cartItems);

        return getCartItemsDetailsResult;
    }

    public async Task<ErrorOr<Cart>> RemoveAllCartItems(string userId)
    {
        var getUserResult = await _userRepository.GetById(userId);
        if (getUserResult.IsError) return getUserResult.Errors;

        var getUserCartResult = _cartRepository.GetByUserId(userId);
        if (getUserCartResult.IsError) return getUserCartResult.Errors;

        var cart = getUserCartResult.Value;
        cart.Items.Clear();
        return await _cartRepository.Update(cart.Id!, cart);
    }

    public async Task<ErrorOr<Cart>> RemoveCartItem(string userId, string productId)
    {
        var getUserResult = await _userRepository.GetById(userId);
        if (getUserResult.IsError) return getUserResult.Errors;

        var getUserCartResult = _cartRepository.GetByUserId(userId);
        if (getUserCartResult.IsError) return getUserCartResult.Errors;

        var getProductResult = await _productRepository.GetById(productId);
        if (getProductResult.IsError) return getProductResult.Errors;

        var cart = getUserCartResult.Value;
        var cartItems = getUserCartResult.Value.Items;
        var item = cartItems.FirstOrDefault(i => i.ProductId == productId);

        if (item is null)
        {
            return Errors.Cart.ItemNotFound(cart.Id!, productId);
        }

        cartItems.Remove(item);

        return await _cartRepository.Update(cart.Id!, cart);
    }

    public async Task<ErrorOr<Cart>> UpdateCart(string id, Cart cart)
    {
        return await _cartRepository.Update(id, cart);
    }
}