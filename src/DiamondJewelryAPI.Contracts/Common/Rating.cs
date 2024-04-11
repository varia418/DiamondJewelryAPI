namespace DiamondJewelryAPI.Contracts.Common;

public record Rating(
    string Id,
    string UserId,
    string ProductId,
    int RatingStar,
    string Content,
    string CreatedAt
);