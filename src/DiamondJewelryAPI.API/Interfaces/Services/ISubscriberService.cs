using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface ISubscriberService
{
    Task<ErrorOr<IEnumerable<Subscriber>>> GetSubscribers();
    Task<ErrorOr<Subscriber>> GetSubscriber(string id);
    Task<ErrorOr<Subscriber>> CreateSubscriber(Subscriber subscriber);
    Task<ErrorOr<Subscriber>> UpdateSubscriber(string id, Subscriber subscriber);
    Task<ErrorOr<Deleted>> DeleteSubscriber(string id);
}