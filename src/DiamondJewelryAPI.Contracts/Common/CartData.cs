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