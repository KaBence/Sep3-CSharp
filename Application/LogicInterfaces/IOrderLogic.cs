using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<string> CreateAsync(OrderCreateDto dto);
    
    Task<IEnumerable<Order>> GetAsync(SearchOrderDto searchParameters);
    Task<Order?> GetByIdAsync(int id,int customerId);

    
    Task DeleteAsync(int id);

    Task UpdateAsync(string status);

    Task<IEnumerable<OrderItem>> GetOrderItemFromOrder(int orderId);
    Task<IEnumerable<OrderItem>> GetOrderItemFromGroup(int orderId);
}