using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    Task<string> CreateProductAsync(ProductCreateDto dto);

    Task EditProduct(UpdateProductDto dto);
    
}