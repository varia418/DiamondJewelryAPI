using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Ratings.Requests;

public record UpsertRatingRequest(
    Rating Rating
);