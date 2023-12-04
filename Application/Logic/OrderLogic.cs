using System.Runtime.InteropServices;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

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

    public Task<IEnumerable<Order>> GetAsync(SearchOrderDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(int id, int customerId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string status)
    {
        throw new NotImplementedException();
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