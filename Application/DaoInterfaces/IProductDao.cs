using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IProductDao
{
    Task<Product> CreateAsync(Product alien);
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters);

    Task UpdateAsync(Product alien);
}