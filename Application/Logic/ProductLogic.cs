using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace Application.Logic;

public class ProductLogic:IProductLogic
{

    private readonly IProductDao productDao;

    public ProductLogic(IProductDao productDao)
    {
        this.productDao = productDao;
    }

    public async Task<string> CreateAsync(ProductCreateDto dto)
    {
        try
        {
            string created = await productDao.CreateAsync(dto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters)
    {
        return productDao.GetAsync(searchParameters);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await productDao.GetByIdAsync(id);
        
    }

    public async Task<IEnumerable<Product>> GetByFarmerAsync(string phoneNumber,SearchProductDto dto)
    {
        return await productDao.GetByFarmer(phoneNumber,dto);
    }

    public async Task<string> UpdateAsync(UpdateProductDto dto)
    {
        return await productDao.UpdateAsync(dto);
    }

    public async Task<string> Delete(int id)
    {
        return await productDao.DeleteAsync(id);
    }
}