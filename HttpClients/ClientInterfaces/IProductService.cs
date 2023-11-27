using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    Task<string> CreateProductAsync(ProductCreateDto dto);

    Task<string> EditProduct(UpdateProductDto dto);
    Task<UpdateProductDto> GetProductByIdAsync(int id);
    Task<string> DeleteAsync(int id);

}