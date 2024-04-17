using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<ErrorOr<Rating>> CreateRating(Rating rating)
    {
        return await _ratingRepository.Create(rating);
    }

    public async Task<ErrorOr<Deleted>> DeleteRating(string id)
    {
        await _ratingRepository.Delete(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Rating>> GetRating(string id)
    {
        return await _ratingRepository.GetById(id);
    }

    public async Task<ErrorOr<IEnumerable<Rating>>> GetRatings()
    {
        return await _ratingRepository.GetAll();
    }

    public async Task<ErrorOr<Rating>> UpdateRating(string id, Rating rating)
    {
        return await _ratingRepository.Update(id, rating);
    }
}