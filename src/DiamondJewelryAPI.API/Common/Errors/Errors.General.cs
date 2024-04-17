using ErrorOr;

using PowerUtils.Text;

namespace DiamondJewelryAPI.API.Common.Errors;

public static partial class Errors
{
    public static class General
    {
        public static Error NotFound(string modelName, string id) => Error.NotFound(
            code: $"{modelName.UppercaseFirst()}.NotFound",
            description: $"{modelName.UppercaseFirst()} with id {id} not found.");
    }
}