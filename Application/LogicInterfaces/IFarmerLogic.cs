using Shared.DTOs;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IFarmerLogic
{
    Task<string> CreateAsync(RegisterFarmerDto farmerDto);
    
    Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters);
    Task<FarmerBasicDto> GetByIdAsync(string phoneNumber);

    
    

    Task<string> UpdateAsync(EditFarmerDto dto);

}