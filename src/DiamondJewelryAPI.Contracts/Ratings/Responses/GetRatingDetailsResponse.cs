using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Ratings.Responses;

public record GetRatingDetailsResponse(
    RatingData Rating
);