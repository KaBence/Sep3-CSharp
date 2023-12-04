using Shared.DTOs;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IFarmerDao
{
    Task<string> CreateAsync(RegisterFarmerDto dto);
    Task<Farmer?> GetByIdAsync(string phonenumber);
    Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters);
    Task<string> UpdateAsync(EditFarmerDto farmerFto);
}