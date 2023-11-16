using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class OrderLogic:IOrderLogic
{
    public Task<Order> CreateAsync(OrderCreateDto dto)
    {
        throw new NotImplementedException();
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
}