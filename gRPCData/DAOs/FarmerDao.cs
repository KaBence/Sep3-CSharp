using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class FarmerDao:IFarmerDao
{
    public async Task<string> CreateAsync(RegisterFarmerDto alien)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateRegisterFarmerRequest(DTOFactory.ToDtoFarmer(alien));
        try
        {
            var response = client.registerFarmer(request);
            string createdFarmer = response.Resp;
            return createdFarmer;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public Task<Farmer?> GetByIdAsync(string phonenumber)
    {
        throw new NotImplementedException();
    }

    public async  Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllFarmersRequest(searchParameters);
        try
        {
            var response = client.getAllFarmers(request);
            List<Farmer> allFarmers = new List<Farmer>();
            foreach (var item in response.AllFarmers)
            {
                allFarmers.Add(DTOFactory.toFarmer(item));
            }

            return allFarmers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;   
        }
    }

    public Task UpdateAsync(Farmer farmer)
    {
        throw new NotImplementedException();
    }
}