using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Basics;
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

    public async Task<FarmerBasicDto> GetByIdAsync(string phoneNumber)
    {
        Farmer? farmer = await FarmerDao.GetByIdAsync(phoneNumber);
        return new FarmerBasicDto(farmer.Phonenumber, farmer.FirstName, farmer.LastName, farmer.Address,
            farmer.Pesticides, farmer.FarmName);
    }

    public async Task<string> UpdateAsync(EditFarmerDto dto)
    {
        try
        {
            string updated = await FarmerDao.UpdateAsync(dto);
            return updated;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

   
}