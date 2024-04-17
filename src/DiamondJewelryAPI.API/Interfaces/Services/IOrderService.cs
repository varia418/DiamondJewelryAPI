using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IOrderService
{
    Task<ErrorOr<IEnumerable<Order>>> GetOrders();
    Task<ErrorOr<Order>> GetOrder(string id);
    Task<ErrorOr<Order>> CreateOrder(Order order);
    Task<ErrorOr<Order>> UpdateOrder(string id, Order order);
    Task<ErrorOr<Deleted>> DeleteOrder(string id);
}