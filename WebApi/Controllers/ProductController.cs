using Application.LogicInterfaces;
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
            SearchProductDto parameters = new SearchProductDto
            {
                Type = type,
                Price = price ?? 0,
                Amount = amount ?? 0
            };
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

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromBody]UpdateProductDto dto)
    {
        try
        {
            await productLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}