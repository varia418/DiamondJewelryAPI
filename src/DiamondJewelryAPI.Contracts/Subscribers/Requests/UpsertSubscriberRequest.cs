using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Subscribers.Requests;

public record UpsertSubscriberRequest(
    Subscriber Subscriber
);