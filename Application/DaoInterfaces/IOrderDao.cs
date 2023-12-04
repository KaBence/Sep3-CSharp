using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Update;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<string> CreateAsync(OrderCreateDto order);
    Task<string> UpdateAsync(AcceptOrder order);
    
    Task<IEnumerable<OrderItem>> GetOrderItemFromOrder(int orderId);
    Task<IEnumerable<OrderItem>> GetOrderItemFromGroup(int orderId);
}