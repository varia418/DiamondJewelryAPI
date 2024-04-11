namespace DiamondJewelryAPI.Contracts.Common;

public record User(
    string Id,
    string FullName,
    string DOB,
    string Tel,
    string Email,
    string Address,
    string Password,
    List<FavoriteProduct> FavoriteProducts,
    string Role,
    string Provider
);

public record FavoriteProduct(
    long Timestamp,
    string Date
);