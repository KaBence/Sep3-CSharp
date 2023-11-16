using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class CustomerDao:ICustomerDao
{
    public Task<Customer> CreateAsync(Customer alien)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByIdAsync(string phonenumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}