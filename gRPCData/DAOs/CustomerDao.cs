using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class CustomerDao:ICustomerDao
{

    public async Task<Customer> CreateAsync(Customer customer)
    {  // put the grpc shit here
        //this has to be redone 
        //why is it ambiguous?
        //potrebujem tuto metodu aby to malo sancu fungovat
        using var channel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(channel);
         client.registerCustomer(new registerCustomerRequest
        {
            NewCustomer = 
        });
        try
        {
            var response = await client.registerCustomer(request);
                
            // Convert the gRPC response back to your local Customer object
            var createdCustomer 
                
                
                
                
                = new Customer
            {
                // Map properties from DtoRegisterCustomer to Customer
                Phonenumber = response.5,
                // Map other properties as needed
            };

            return createdCustomer;
        }
        catch (RpcException ex)
        {
            // Handle gRPC communication errors
            // Log the error or take appropriate action
            Console.WriteLine($"gRPC Error: {ex.Status}");
            throw;
        }
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