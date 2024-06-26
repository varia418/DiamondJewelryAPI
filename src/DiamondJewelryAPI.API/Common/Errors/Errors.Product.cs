using ErrorOr;

namespace DiamondJewelryAPI.API.Common.Errors;

public static partial class Errors
{
    public static class Product
    {
        public static Error FilterNotFound => Error.Validation(
            code: "Product.FilterNotFound",
            description: "Filter not found");
    }
}