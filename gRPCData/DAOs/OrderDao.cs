using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace gRPCData.DAOs;

public class OrderDao : IOrderDao
{
    public async Task<string> CreateAsync(OrderCreateDto order)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateOrderRequest(order);
        try
        {
            var response = client.createNewOrder(request);
            return response.Resp;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<string> UpdateAsync(AcceptOrder order)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.acceptOrder(order);
        try
        {
            var response = client.farmersApproval(request);
            return response.Resp;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemFromOrder(int orderId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllOrderItemsFromOrderRequest(orderId);
        List<OrderItem> orderItems = new List<OrderItem>();
        try
        {
            var response = client.getAllOrderItemsFromOrder(request);
            foreach(DtoOrderItem item in response.OrderItems)
            {
                orderItems.Add(DTOFactory.ToOrderItem(item));
            }

            return orderItems;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemFromGroup(int orderId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllOrderItemsByGroupRequest(orderId);
        List<OrderItem> orderItems = new List<OrderItem>();
        try
        {
            var response = client.getAllOrderItemsByGroup(request);
            foreach(DtoOrderItem item in response.OrderItems)
            {
                orderItems.Add(DTOFactory.ToOrderItem(item));
            }

            return orderItems;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
}