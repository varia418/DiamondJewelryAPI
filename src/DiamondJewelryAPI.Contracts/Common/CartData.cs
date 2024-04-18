namespace DiamondJewelryAPI.Contracts.Common;

public record CartData(
    string Id,
    string UserId,
    CartItemData[] Items
);

public record CartItemData(
    string Id,
    int Quantity
);

public record CartItemDetailsData(
    string? Id,
    string Title,
    string Description,
    ProductDetails Details,
    string Group,
    string Image,
    string? CreatedAt,
    int Quantity,
    int Price = 0,
    int Stock = 0,
    int Sold = 0
);