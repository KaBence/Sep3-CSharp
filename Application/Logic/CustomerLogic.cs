using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.DTOs.Basics;
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

    public async Task<IEnumerable<Customer>> GetAsync()
    {
        return  await CustomerDao.GetAsync();
    }
    

    public async Task<CustomerBasicDto> GetByIdAsync(string phoneNumber)
    {
        Customer? customer = await CustomerDao.GetByIdAsync(phoneNumber);
        return new CustomerBasicDto(customer.Phonenumber, customer.FirstName, customer.LastName, customer.Address);
    }

    public async Task<string> UpdateAsync(EditCustomerDto dto)
    {
        try
        {
            string updated = await CustomerDao.UpdateAsync(dto);
            return updated;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}