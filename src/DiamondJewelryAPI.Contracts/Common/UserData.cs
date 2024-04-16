namespace DiamondJewelryAPI.Contracts.Common;

public record UserData(
    string? Id,
    string FullName,
    string? DOB,
    string? Tel,
    string Email,
    string? Address,
    string? Password,
    List<string>? FavoriteProducts,
    string Role,
    string Provider
);