using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    Task<string> CreateProductAsync(ProductCreateDto dto);

    Task<string> EditProduct(UpdateProductDto dto);
    Task<UpdateProductDto> GetProductByIdAsync(int id);
    Task<string> DeleteAsync(int id);
    Task<IEnumerable<Product>> getByFarmerAsync(string farmName);
    Task<IEnumerable<Product>> getAsync(SearchProductDto searchParameters);

}