using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface ISubscriberService
{
    Task<ErrorOr<IEnumerable<Subscriber>>> GetSubscribers();
}