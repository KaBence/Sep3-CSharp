using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    Task<string> CreateAsync(RegisterCustomerDto customerDto);
    
    Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters);
    Task<Customer?> GetByIdAsync(int id);

    

    Task UpdateAsync(Customer dto);
}