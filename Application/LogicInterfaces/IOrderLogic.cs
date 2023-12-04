using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<string> CreateAsync(OrderCreateDto dto);
    Task<string> UpdateAsync(AcceptOrder order);
}