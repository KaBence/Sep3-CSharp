using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<string> CreateAsync(OrderCreateDto order);
    Task<string> UpdateAsync(AcceptOrder order);
}