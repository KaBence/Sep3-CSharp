using Sep;
using Shared.DTOs;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface ICustomerDao
{
    Task<string> CreateAsync(RegisterCustomerDto dto);
    Task<Customer?> GetByIdAsync(string phonenumber);
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters);
    
    Task UpdateAsync(Customer customer);
    
}