using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class FarmerLogic:IFarmerLogic

{
    private readonly IFarmerDao FarmerDao;

    public FarmerLogic(IFarmerDao farmerDao)
    {
        FarmerDao = farmerDao;
    }
    public  async Task<string> CreateAsync(RegisterFarmerDto farmerDto)
    {
        try
        {
            string created = await FarmerDao.CreateAsync(farmerDto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters)
    {
        return FarmerDao.GetAsync(searchParameters);
    }

    public Task<Farmer?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Farmer dto)
    {
        throw new NotImplementedException();
    }
}