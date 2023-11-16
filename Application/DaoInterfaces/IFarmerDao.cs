using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IFarmerDao
{
    Task<Farmer> CreateAsync(Farmer alien);
    Task<Farmer?> GetByIdAsync(string phonenumber);
    Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters);
    
    Task UpdateAsync(Farmer farmer);
}