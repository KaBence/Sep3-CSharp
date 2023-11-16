using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class FarmerLogic:IFarmerLogic
{
    public Task<Farmer> CreateAsync(FarmerCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters)
    {
        throw new NotImplementedException();
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