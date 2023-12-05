using Shared.DTOs.Update;
using Shared.Models;

namespace HttpClients.ClientInterfaces;
using Shared.DTOs.Create;

public interface IOrderService
{
    Task<string> CreateOrderAsync(OrderCreateDto dto);

    Task<string> AcceptOrder(AcceptOrder order);
    Task<IEnumerable<OrderItem>> GetAllOrderItemsFromOrder(int orderId);
    Task<IEnumerable<OrderItem>> GetAllOrderItemsFromGroup(int orderId);
}