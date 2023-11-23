using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IProductLogic
{
    Task<string> CreateAsync(ProductCreateDto dto);
    
    Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters);
    Task<Product> GetByIdAsync(int id);
    
    Task<string> UpdateAsync(UpdateProductDto dto);
}