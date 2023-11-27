using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace gRPCData.DAOs;

public class ProductDao: IProductDao
{
    public async Task<string> CreateAsync(ProductCreateDto alien)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateProductRequest(DTOFactory.toDtoProduct(alien));
        try
        {
            var response = client.createProduct(request);
            string createdFarmer = response.Resp;
            return createdFarmer;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetProductByIdRequest(id);
        try
        {
            var response = client.getProductById(request);
            if (response.Product==null)
            {
                throw new Exception($"Product with id {id} was not found");
            }
            return DTOFactory.toProduct(response.Product);
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllProductsRequest(searchParameters);
        try
        {
            var response = client.getAllProducts(request);
            List<Product> products = new List<Product>();
            foreach (var item in response.AllProducts)
            {
                products.Add(DTOFactory.toProduct(item));
            }

            return products;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<string> UpdateAsync(UpdateProductDto alien)
    {
        Product existing = await GetByIdAsync(alien.Id);
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        DtoProduct dto = new DtoProduct
        {
            FarmerId = existing.FarmerID,
            Id = alien.Id,
            Amount = alien.Amount??existing.Amount,
            Availability = alien.Availability??existing.Availability,
            ExpirationDate = alien.ExpirationDate??existing.ExpirationDate,
            PickedDate = alien.PickedDate??existing.PickedDate,
            Price = alien.Price??existing.Price,
            Type = alien.Type??existing.Type
        };
        
        
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateUpdateProductRequest(dto);
        try
        {
            var response = client.updateProduct(request);
            if (response.Resp.Contains("Error"))
            {
                throw new Exception(response.Resp);
            }
            return response.Resp;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
    

    public async Task<string> DeleteAsync(int id)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.DeleteProductRequest(id);
        try
        {
            var response = client.deleteProduct(request);
            return response.Resp;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
}