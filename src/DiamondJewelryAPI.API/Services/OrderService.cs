using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<Order>> CreateOrder(Order order)
    {
        return await _orderRepository.Create(order);
    }

    public async Task<ErrorOr<Deleted>> DeleteOrder(string id)
    {
        await _orderRepository.Delete(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Order>> GetOrder(string id)
    {
        return await _orderRepository.GetById(id);
    }

    public async Task<ErrorOr<IEnumerable<Order>>> GetOrders()
    {
        return await _orderRepository.GetAll();
    }

    public async Task<ErrorOr<Order>> UpdateOrder(string id, Order order)
    {
        return await _orderRepository.Update(id, order);
    }
}