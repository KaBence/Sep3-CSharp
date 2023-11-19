using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
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
    public async Task<ActionResult<Customer>> CreateAsync(RegisterCustomerDto customerDto)
    {
        try
        {
            Customer customer = await customerLogic.CreateAsync(customerDto);
            return Created($"/customer/{customer.Phonenumber}", customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}