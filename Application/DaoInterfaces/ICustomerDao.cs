using Shared.DTOs;
using Shared.Models;
namespace Application.DaoInterfaces;

public interface ICustomerDao
{
    Task<string> CreateAsync(RegisterCustomerDto dto);
    Task<Customer?> GetByIdAsync(string phonenumber);
    Task<IEnumerable<Customer>> GetAsync();
    Task<string> UpdateAsync(EditCustomerDto customerDto);
    
}