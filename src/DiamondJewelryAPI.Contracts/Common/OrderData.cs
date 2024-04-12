namespace DiamondJewelryAPI.Contracts.Common;

public record OrderData(
    string Id,
    string UserId,
    OrderItem[] Items,
    string Address,
    string Status,
    long VATFee,
    long TotalCost,
    string CreatedAt
);

public record OrderItem(
    string ProductId,
    int Quantity
);