using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Basics;
using Shared.Models;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ReceiptController: ControllerBase
{
    private readonly IReceiptLogic receiptLogic;

    public ReceiptController(IReceiptLogic receiptLogic)
    {
        this.receiptLogic = receiptLogic;
    }
    //getAllByCustomer
    //getPending by farmer
    //getAccepted  by farmer
    //getRejecting  by farmer

    [HttpGet("ByCustomer/{customerId:required}")]
    public async Task<ActionResult<IEnumerable<CustomerSendReceiptDto>>> getAllReceiptsByCustomer([FromRoute] string customerId)
    {
        try
        {
            IEnumerable<CustomerSendReceiptDto> receipts = await receiptLogic.GetAllReceiptsByCustomerAsync(customerId);
            return Ok(receipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}