using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IRatingService
{
    Task<ErrorOr<IEnumerable<Rating>>> GetRatings();
    Task<ErrorOr<IEnumerable<Rating>>> GetProductRatings(string productId);
    Task<ErrorOr<Rating>> GetRating(string id);
    Task<ErrorOr<Rating>> CreateRating(Rating rating);
    Task<ErrorOr<Rating>> UpdateRating(string id, Rating rating);
    Task<ErrorOr<Deleted>> DeleteRating(string id);
}