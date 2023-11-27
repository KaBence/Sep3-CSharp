using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    Task<string> CreateProductAsync(ProductCreateDto dto);

    Task EditProduct(UpdateProductDto dto);

    Task<IEnumerable<Product>> getAsync(SearchProductDto searchParameters);

}