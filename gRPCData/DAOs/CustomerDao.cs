using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class CustomerDao:ICustomerDao
{
    
    public async Task<Customer> CreateAsync(Customer alien)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        await client.registerCustomer(new registerCustomerRequest()
        {
            NewCustomer = alien.Phonenumber
        });
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