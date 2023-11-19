using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;


public class CustomerLogic:ICustomerLogic
{
    private readonly ICustomerDao customerDao;
    public async Task<Customer> CreateAsync(RegisterCustomerDto customerDto)
    {
        
        
        Customer toCreate = new Customer
        {
            Phonenumber = customerDto.Phonenumber
        };
        try
        {
            Customer created = await customerDao.CreateAsync(toCreate);
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