using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class SubscribersController : ApiController
{
    private readonly ISubscriberService _subscriberService;

    public SubscribersController(ISubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubscribers()
    {
        ErrorOr<IEnumerable<Subscriber>> getSubscribersResult = await _subscriberService.GetSubscribers();

        return getSubscribersResult.Match(
            subscribers => Ok(subscribers),
            errors => Problem(errors)
        );
    }
}