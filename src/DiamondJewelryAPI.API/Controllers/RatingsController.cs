using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class RatingsController : ApiController
{
    private readonly IRatingService _ratingService;
    private readonly IMapper _mapper;


    public RatingsController(IRatingService ratingService, IMapper mapper)
    {
        _ratingService = ratingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRatings()
    {
        ErrorOr<IEnumerable<Rating>> getRatingsResult = await _ratingService.GetRatings();

        return getRatingsResult.Match(
            ratings => Ok(ratings),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRatingDetails(string id)
    {
        ErrorOr<Rating> getRatingDetailsResult = await _ratingService.GetRating(id);

        return getRatingDetailsResult.Match(
            rating => Ok(rating),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateRating(RatingData request)
    {
        Rating rating = _mapper.Map<Rating>(request);
        ErrorOr<Rating> createRatingResult = await _ratingService.CreateRating(rating);

        return createRatingResult.Match(
            rating => Ok(_mapper.Map<RatingData>(rating)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRating(RatingData request)
    {
        Rating rating = _mapper.Map<Rating>(request);

        if (rating.Id is null) return BadRequest();

        ErrorOr<Rating> updateRatingResult = await _ratingService.UpdateRating(rating.Id, rating);

        return updateRatingResult.Match(
            rating => Ok(_mapper.Map<RatingData>(rating)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(string id)
    {
        ErrorOr<Deleted> deleteRatingsResult = await _ratingService.DeleteRating(id);

        return deleteRatingsResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}