using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IOrderItemDao
{
    Task<OrderItem> CreateAsync(OrderItem alien);
    Task<OrderItem?> GetByIdAsync(int orderId,int productId);
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemDto searchParameters);

    Task UpdateAsync(OrderItem alien);
    Task DeleteAsync(int orderId, int productId);
}