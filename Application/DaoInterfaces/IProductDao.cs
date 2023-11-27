using Shared.DTOs.Create;
using Shared.Models;
using Shared.DTOs.Search;
using Shared.DTOs.Update;

namespace Application.DaoInterfaces;

public interface IProductDao
{
    Task<string> CreateAsync(ProductCreateDto alien);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters);

    Task<string> UpdateAsync(UpdateProductDto alien);
    Task<string> DeleteAsync(int id);
    Task<IEnumerable<Product>> GetByFarmer(string phoneNumber);
}