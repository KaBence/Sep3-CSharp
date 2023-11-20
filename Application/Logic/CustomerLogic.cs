using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;


public class CustomerLogic:ICustomerLogic
{
    private readonly ICustomerDao CustomerDao;

    public CustomerLogic(ICustomerDao customerDao)
    {
        CustomerDao = customerDao;
    }
    public async Task<string> CreateAsync(RegisterCustomerDto customerDto)
    {
        
        
        
        try
        {
            string created = await CustomerDao.CreateAsync(customerDto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
   
    public Task<IEnumerable<Customer>> GetAsync(SearchCustomerDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer dto)
    {
        throw new NotImplementedException();
    }
}