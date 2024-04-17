using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class SubscriberService : ISubscriberService
{
    private readonly ISubscriberRepository _subscriberRepository;

    public SubscriberService(ISubscriberRepository subscriberRepository)
    {
        _subscriberRepository = subscriberRepository;
    }

    public async Task<ErrorOr<Subscriber>> CreateSubscriber(Subscriber subscriber)
    {
        return await _subscriberRepository.Create(subscriber);
    }

    public async Task<ErrorOr<Deleted>> DeleteSubscriber(string id)
    {
        await _subscriberRepository.Delete(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Subscriber>> GetSubscriber(string id)
    {
        return await _subscriberRepository.GetById(id);
    }

    public async Task<ErrorOr<IEnumerable<Subscriber>>> GetSubscribers()
    {
        return await _subscriberRepository.GetAll();
    }

    public async Task<ErrorOr<Subscriber>> UpdateSubscriber(string id, Subscriber subscriber)
    {
        return await _subscriberRepository.Update(id, subscriber);
    }
}