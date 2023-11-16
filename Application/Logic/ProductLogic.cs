using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ProductLogic:IProductLogic
{
    public Task<Product> CreateAsync(ProductCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product dto)
    {
        throw new NotImplementedException();
    }
}