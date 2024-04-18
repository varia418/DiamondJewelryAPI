using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Models.Common;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class CartsController : ApiController
{
    private readonly ICartService _cartService;
    private readonly IMapper _mapper;


    public CartsController(ICartService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCarts()
    {
        ErrorOr<IEnumerable<Cart>> getCartsResult = await _cartService.GetCarts();

        return getCartsResult.Match(
            carts => Ok(carts),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartDetails(string id)
    {
        ErrorOr<Cart> getCartDetailsResult = await _cartService.GetCart(id);

        return getCartDetailsResult.Match(
            cart => Ok(cart),
            errors => Problem(errors)
        );
    }

    [HttpGet("cartItems/{userId}")]
    public async Task<IActionResult> GetUserCartItemsWithDetails(string userId)
    {
        ErrorOr<IEnumerable<CartItemDetails>> getCartItemsResult = await _cartService.GetUserCartItemsWithDetails(userId);

        return getCartItemsResult.Match(
            cartItems => Ok(_mapper.Map<IEnumerable<CartItemDetailsData>>(cartItems)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateCart(CartData request)
    {
        Cart cart = _mapper.Map<Cart>(request);
        ErrorOr<Cart> createCartResult = await _cartService.CreateCart(cart);

        return createCartResult.Match(
            cart => Ok(_mapper.Map<CartData>(cart)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCart(CartData request)
    {
        Cart cart = _mapper.Map<Cart>(request);

        if (cart.Id is null) return BadRequest();

        ErrorOr<Cart> updateCartResult = await _cartService.UpdateCart(cart.Id, cart);

        return updateCartResult.Match(
            cart => Ok(_mapper.Map<CartData>(cart)),
            errors => Problem(errors));
    }

    [HttpPut("removeItem/{userId}")]
    public async Task<IActionResult> RemoveCartItem(string userId, [FromBody] string productId)
    {
        ErrorOr<Cart> updateCartResult = await _cartService.RemoveCartItem(userId, productId);

        return updateCartResult.Match(
            cart => Ok(_mapper.Map<CartData>(cart)),
            errors => Problem(errors));
    }

    [HttpPut("removeAllItems/{userId}")]
    public async Task<IActionResult> RemoveAllCartItems(string userId)
    {
        ErrorOr<Cart> updateCartResult = await _cartService.RemoveAllCartItems(userId);

        return updateCartResult.Match(
            cart => Ok(_mapper.Map<CartData>(cart)),
            errors => Problem(errors));
    }

    [HttpPut("addItem/{userId}")]
    public async Task<IActionResult> AddCartItem([FromRoute] string userId, [FromBody] CartItemData cartItemData)
    {
        CartItem cartItem = _mapper.Map<CartItem>(cartItemData);

        if (cartItem.ProductId is null) return BadRequest();

        ErrorOr<Cart> updateCartResult = await _cartService.AddCartItem(userId, cartItem);

        var cart = updateCartResult.Value;
        var temp = _mapper.Map<CartData>(cart);

        return updateCartResult.Match(
            cart => Ok(_mapper.Map<CartData>(cart)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(string id)
    {
        ErrorOr<Deleted> deleteCartsResult = await _cartService.DeleteCart(id);

        return deleteCartsResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}