using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Ratings.Responses;

public record GetProductRatingsResponse(
    Rating[] Ratings
);