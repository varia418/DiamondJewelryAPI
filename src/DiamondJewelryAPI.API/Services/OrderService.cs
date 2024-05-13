using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;


    public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Order>> CreateOrder(Order order)
    {
        var getUserResult = await _userRepository.GetById(order.UserId);
        if (getUserResult.IsError) return getUserResult.Errors;

        order.Address = getUserResult.Value.Address;
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

    public async Task<ErrorOr<Order>> UpdateOrderStatus(string id, string status)
    {
        var getOrderResult = await _orderRepository.GetById(id);

        if (getOrderResult.IsError)
        {
            return getOrderResult.Errors;
        }

        getOrderResult.Value.UpdateStatus(status);

        return await _orderRepository.Update(id, getOrderResult.Value);
    }
}