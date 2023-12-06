using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs.Search;
using Shared.Models;
using Sep;
using Shared.DTOs;

namespace gRPCData.DAOs;

public class CustomerDao:ICustomerDao
{
    public async Task<string> CreateAsync(RegisterCustomerDto alien)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateRegisterCustomerRequest(DTOFactory.ToDtoCustomer(alien));
        try
        {
            
            var response = client.registerCustomer(request);
            string createdCustomer = response.Resp;
            return createdCustomer;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }

    }


    public async Task<Customer?> GetByIdAsync(string phonenumber)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetCustomerByPhoneRequest(phonenumber);
        try
        {
            var response = client.getCustomerByPhone(request);
          Customer result=  DTOFactory.toCustomer(response.Customer);
          return result;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetAsync()
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllCustomersRequest();
        try
        {
            var response = client.getAllCustomers(request);
            List<Customer> allCustomers = new List<Customer>();
            foreach (var item in response.AllCustomers)
            {
                allCustomers.Add(DTOFactory.toCustomer(item));
            }

            return allCustomers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;   
        }
    }

    public async Task<string> UpdateAsync(EditCustomerDto customerDto)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateEditCustomerRequest(DTOFactory.ToDtoCustomerForEditing(customerDto));
        try
        {
            var response = client.editCustomer(request);
            string editedCustomer = response.Resp;
            return editedCustomer; 
        }
        
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

 
}