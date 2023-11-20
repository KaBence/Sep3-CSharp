using Sep;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface ICustomerDao
{
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer?> GetByIdAsync(string phonenumber);
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters);
    
    Task UpdateAsync(Customer customer);
    
}