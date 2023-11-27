using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.DTOs.Basics;
using Shared.DTOs.Search;
using Shared.Models;

namespace WebAPI.Controllers; 
[ApiController]
[Route("[controller]")]
public class CustomerController: ControllerBase
{
    private readonly ICustomerLogic customerLogic;

    public CustomerController(ICustomerLogic customerLogic)
    {
        this.customerLogic = customerLogic;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(RegisterCustomerDto customerDto)
    {
        try
        {
            string customer = await customerLogic.CreateAsync(customerDto);
            return Ok(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
    {
        try
        {

            IEnumerable<Customer> customers = await customerLogic.GetAsync();
            return Ok(customers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }

   [HttpGet("{phoneNumer:required}")]
    public async Task<ActionResult<Customer>> GetAsync([FromRoute]string phoneNumer)
    {
        try
        {
            CustomerBasicDto result = await customerLogic.GetByIdAsync(phoneNumer);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<string>> UpdateAsync([FromBody] EditCustomerDto dto)
    {
        try
        { 
            string updatedCustomer= await customerLogic.UpdateAsync(dto);
            return Ok(updatedCustomer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    

}