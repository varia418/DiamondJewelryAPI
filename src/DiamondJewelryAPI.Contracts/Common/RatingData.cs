namespace DiamondJewelryAPI.Contracts.Common;

public record RatingData(
    string Id,
    string UserId,
    string ProductId,
    int RatingStar,
    string Content,
    string CreatedAt
);