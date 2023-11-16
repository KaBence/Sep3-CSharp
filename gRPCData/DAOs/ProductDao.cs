using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class ProductDao: IProductDao
{
    public Task<Product> CreateAsync(Product alien)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product alien)
    {
        throw new NotImplementedException();
    }
}