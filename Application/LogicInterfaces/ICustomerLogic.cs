using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    Task<Customer> CreateAsync(CustomerCreateDto dto);
    
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters);
    Task<Customer?> GetByIdAsync(int id);

    

    Task UpdateAsync(Customer dto);
}