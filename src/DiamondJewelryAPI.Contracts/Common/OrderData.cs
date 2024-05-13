namespace DiamondJewelryAPI.Contracts.Common;

public record OrderData(
    string? Id,
    string UserId,
    OrderItem[] Items,
    string? Address,
    long VATFee,
    long TotalCost,
    string CreatedAt,
    string Status = "Đang xử lý"
);

public record OrderItem(
    string ProductId,
    int Quantity
);