using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs.Search;
using Shared.Models;
using Sep;
namespace gRPCData.DAOs;

public class CustomerDao:ICustomerDao
{
    public async Task<Customer> CreateAsync(Customer alien)
    {
        //. change to return the string
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = new registerCustomerRequest
        {
            NewCustomer = new DtoRegisterCustomer
            {
                PhoneNumber = alien.Phonenumber
            }
        };
        try
        {
            
            var response = client.registerCustomer(request);
            var createdCustomer = new Customer
            {
                Phonenumber = response.Resp
            };
            return createdCustomer;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }

    }


    public Task<Customer?> GetByIdAsync(string phonenumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}