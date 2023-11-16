using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class FarmerDao:IFarmerDao
{
    public Task<Farmer> CreateAsync(Farmer alien)
    {
        throw new NotImplementedException();
    }

    public Task<Farmer?> GetByIdAsync(string phonenumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Farmer farmer)
    {
        throw new NotImplementedException();
    }
}