using ErrorOr;

namespace DiamondJewelryAPI.API.Common.Errors;

public static partial class Errors
{
    public static class Cart
    {
        public static Error NotFound(string userId) => Error.NotFound(
            code: "Cart.NotFound",
            description: $"Can not find cart of user {userId}");

        public static Error ItemNotFound(string cartId, string productId) => Error.NotFound(
            code: "Cart.ItemNotFound",
            description: $"Can not find item {productId} in cart {cartId}");
    }
}