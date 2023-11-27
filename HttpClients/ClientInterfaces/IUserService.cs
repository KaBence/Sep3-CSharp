using System.Globalization;
using System.Threading.Tasks;
using Shared.DTOs;
using Shared.DTOs.Search;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<string> Register(RegisterCustomerDto dto);
    Task<string> Register(RegisterFarmerDto dto);

    Task<string> EditFarmer(EditFarmerDto dto);
    Task<string> EditCustomer(EditCustomerDto dto);
    
    Task<EditCustomerDto> GetCustomerByIdAsync(string phoneNumber);
    Task<EditFarmerDto> GetFarmerByIdAsync(string phoneNumber);

    Task<IEnumerable<Farmer>> GetAllFarmers(SearchFarmerDto searchParameters);
}