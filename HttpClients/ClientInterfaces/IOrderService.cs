using Shared.DTOs.Update;

namespace HttpClients.ClientInterfaces;
using Shared.DTOs.Create;

public interface IOrderService
{
    Task<string> CreateOrderAsync(OrderCreateDto dto);

    Task<string> AcceptOrder(AcceptOrder order);
}