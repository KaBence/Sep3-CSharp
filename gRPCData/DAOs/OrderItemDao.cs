using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class OrderItemDao: IOrderItemDao
{
    public Task<OrderItem> CreateAsync(OrderItem alien)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem?> GetByIdAsync(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderItem alien)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int orderId, int productId)
    {
        throw new NotImplementedException();
    }
}