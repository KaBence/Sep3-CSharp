using Application.Logic;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IOrderItemLogic
{
    Task<OrderItem> CreateAsync(OrderItemCreateDto dto);
    
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemDto searchParameters);
    Task<OrderItem?> GetByIdAsync(int orderId,int productId);

    
    Task DeleteAsync(int orderId, int productId);

    Task UpdateAsync(OrderItem dto);

}