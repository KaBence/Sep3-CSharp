using System.Diagnostics;
using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class ReceiptDao: IReceiptDao
{
    public async Task<string> CreateAsync(Receipt alien)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateAsync(ReceiptCreateDto alien)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateReceiptRequest(DTOFactory.toDtoReceipt(alien));
        try
        {
            var response = client.createReceipt(request);
            string createdReceipt = response.Resp;
            return createdReceipt;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public Task<Receipt?> GetByIdAsync(int orderId, int farmerId, int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllReceiptsRequest(searchParameters);
        try
        {
            var response = client.getAllReceipts(request);
            List<Receipt> receipts = new List<Receipt>();
            foreach (var item in response.AllReceipts)
            {
                receipts.Add(DTOFactory.toReceipt(item));
            }

            return receipts;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<Receipt?> GetByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }
}