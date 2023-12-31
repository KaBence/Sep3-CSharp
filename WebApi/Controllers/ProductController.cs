﻿using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductLogic productLogic;

    public ProductController(IProductLogic productLogic)
    {
        this.productLogic = productLogic;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(ProductCreateDto dto)
    {
        try
        {
            string product = await productLogic.CreateAsync(dto);
            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAsync([FromQuery] string? type, [FromQuery] double? price,
        [FromQuery] double? amount)
    {
        try
        {
            SearchProductDto parameters = new(type, price, amount);
            IEnumerable<Product> products = await productLogic.GetAsync(parameters);
            return Ok(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            Product product=await productLogic.GetByIdAsync(id);
            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("ByFarmer/{phoneNumber:required}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetByFarmer([FromRoute] string phoneNumber,[FromQuery] string? type, [FromQuery] double? price,
        [FromQuery] double? amount)
    {
        try
        {
            SearchProductDto dto = new SearchProductDto(type, price, amount);
            IEnumerable<Product> list = await productLogic.GetByFarmerAsync(phoneNumber,dto);
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<string>> UpdateAsync(UpdateProductDto dto)
    {
        try
        {
            string msg= await productLogic.UpdateAsync(dto);
            return Ok(msg);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute]int id)
    {
        try
        {
            string delete = await productLogic.Delete(id);
            return Ok(delete);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}