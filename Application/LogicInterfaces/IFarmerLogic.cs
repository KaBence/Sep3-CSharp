using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IFarmerLogic
{
    Task<Farmer> CreateAsync(FarmerCreateDto dto);
    
    Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters);
    Task<Farmer?> GetByIdAsync(int id);

    

    Task UpdateAsync(Farmer dto);

}