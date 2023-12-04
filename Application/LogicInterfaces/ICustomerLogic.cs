using Shared.DTOs;
using Shared.DTOs.Basics;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    Task<string> CreateAsync(RegisterCustomerDto customerDto);
    Task<IEnumerable<Customer>> GetAsync();
    Task<CustomerBasicDto> GetByIdAsync(string phoneNumber);
    Task<string> UpdateAsync(EditCustomerDto dto);
}