namespace DiamondJewelryAPI.Contracts.Common;

public record CartData(
    string Id,
    string UserId,
    CartItem[] Items
);

public record CartItem(
    string ProductId,
    int Quantity
);