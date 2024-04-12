using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Subscribers.Responses;

public record UpsertSubscriberResponse(
    SubscriberData Subscriber
);