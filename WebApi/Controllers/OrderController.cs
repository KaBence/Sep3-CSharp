using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderLogic orderLogic;

    public OrderController(IOrderLogic orderLogic)
    {
        this.orderLogic = orderLogic;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(OrderCreateDto dto)
    {
        try
        {
            string order = await orderLogic.CreateAsync(dto);
            return Ok(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet,Route("Single")]
    public async Task<ActionResult<OrderItem>> GetAllOrderItemsFromOrder(int orderId)
    {
        try
        {
            IEnumerable<OrderItem> order = await orderLogic.GetOrderItemFromOrder(orderId);
            return Ok(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet,Route("Group")]
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItemFromGroup(int orderId)
    {
        try
        {
            IEnumerable<OrderItem> order = await orderLogic.GetOrderItemFromGroup(orderId);
            return Ok(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}