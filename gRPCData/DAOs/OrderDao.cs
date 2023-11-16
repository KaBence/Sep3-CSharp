using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class OrderDao : IOrderDao
{
    public Task<Order> CreateAsync(Order alien)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string status)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int orderId)
    {
        throw new NotImplementedException();
    }
}