using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Subscribers.Responses;

public record GetSubscribersResponse(
    Subscriber[] Subscribers
);