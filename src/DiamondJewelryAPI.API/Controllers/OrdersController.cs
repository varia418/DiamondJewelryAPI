using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class OrdersController : ApiController
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;


    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        ErrorOr<IEnumerable<Order>> getOrdersResult = await _orderService.GetOrders();

        return getOrdersResult.Match(
            orders => Ok(orders),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetails(string id)
    {
        ErrorOr<Order> getOrderDetailsResult = await _orderService.GetOrder(id);

        return getOrderDetailsResult.Match(
            order => Ok(order),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderData request)
    {
        Order order = _mapper.Map<Order>(request);
        ErrorOr<Order> createOrderResult = await _orderService.CreateOrder(order);

        return createOrderResult.Match(
            order => Ok(_mapper.Map<OrderData>(order)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(OrderData request)
    {
        Order order = _mapper.Map<Order>(request);

        if (order.Id is null) return BadRequest();

        ErrorOr<Order> updateOrderResult = await _orderService.UpdateOrder(order.Id, order);

        return updateOrderResult.Match(
            order => Ok(_mapper.Map<OrderData>(order)),
            errors => Problem(errors));
    }

    [HttpPut("updateStatus/{id}")]
    public async Task<IActionResult> UpdateOrderStatus(string id, [FromBody] string status)
    {
        ErrorOr<Order> updateOrderResult = await _orderService.UpdateOrderStatus(id, status);

        return updateOrderResult.Match(
            order => Ok(_mapper.Map<OrderData>(order)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        ErrorOr<Deleted> deleteOrdersResult = await _orderService.DeleteOrder(id);

        return deleteOrdersResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}