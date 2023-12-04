using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace Application.Logic;

public class OrderLogic:IOrderLogic
{
    private readonly IOrderDao orderDao;

    public OrderLogic(IOrderDao orderDao)
    {
        this.orderDao = orderDao;
    }

    public async Task<string> CreateAsync(OrderCreateDto dto)
    {
        return await orderDao.CreateAsync(dto);
    }

    public async Task<string> UpdateAsync(AcceptOrder order)
    {
        return await orderDao.UpdateAsync(order);
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemFromOrder(int orderId)
    {
        return await orderDao.GetOrderItemFromOrder(orderId);
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemFromGroup(int orderId)
    {
        return await orderDao.GetOrderItemFromGroup(orderId);
    }
}