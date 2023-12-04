using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<string> CreateAsync(OrderCreateDto order);
    Task<Order?> GetByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetAsync(SearchOrderDto searchParameters);

    Task UpdateAsync(string status);
    Task DeleteAsync(int orderId);
    
    
    Task<IEnumerable<OrderItem>> GetOrderItemFromOrder(int orderId);
    Task<IEnumerable<OrderItem>> GetOrderItemFromGroup(int orderId);
}