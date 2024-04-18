using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class SubscribersController : ApiController
{
    private readonly ISubscriberService _subscriberService;
    private readonly IMapper _mapper;

    public SubscribersController(ISubscriberService subscriberService, IMapper mapper)
    {
        _subscriberService = subscriberService;
        _mapper = mapper;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriberDetails(string id)
    {
        ErrorOr<Subscriber> getSubscriberDetailsResult = await _subscriberService.GetSubscriber(id);

        return getSubscriberDetailsResult.Match(
            subscriber => Ok(subscriber),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateSubscriber(SubscriberData request)
    {
        Subscriber subscriber = _mapper.Map<Subscriber>(request);
        ErrorOr<Subscriber> createSubscriberResult = await _subscriberService.CreateSubscriber(subscriber);

        return createSubscriberResult.Match(
            subscriber => Ok(_mapper.Map<SubscriberData>(subscriber)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubscriber(SubscriberData request)
    {
        Subscriber subscriber = _mapper.Map<Subscriber>(request);

        if (subscriber.Id is null) return BadRequest();

        ErrorOr<Subscriber> updateSubscriberResult = await _subscriberService.UpdateSubscriber(subscriber.Id, subscriber);

        return updateSubscriberResult.Match(
            subscriber => Ok(_mapper.Map<SubscriberData>(subscriber)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscriber(string id)
    {
        ErrorOr<Deleted> deleteSubscribersResult = await _subscriberService.DeleteSubscriber(id);

        return deleteSubscribersResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}