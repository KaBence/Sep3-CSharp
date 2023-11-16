using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IProductLogic
{
    Task<Product> CreateAsync(ProductCreateDto dto);
    
    Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters);
    Task<Product?> GetByIdAsync(int id);
    
    Task UpdateAsync(Product dto);
}