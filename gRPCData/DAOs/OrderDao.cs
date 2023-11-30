using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

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