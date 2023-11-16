using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class OrderItemLogic:IOrderItemLogic
{
    public Task<OrderItem> CreateAsync(OrderItemCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem?> GetByIdAsync(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderItem dto)
    {
        throw new NotImplementedException();
    }
}