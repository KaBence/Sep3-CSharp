using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<string> CreateAsync(OrderCreateDto dto);
    Task<string> UpdateAsync(AcceptOrder order);
}