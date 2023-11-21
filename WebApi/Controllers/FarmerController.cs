using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FarmerController: ControllerBase

{
    private readonly IFarmerLogic FarmerLogic;

    private FarmerController(IFarmerLogic farmerLogic)
    {
        this.FarmerLogic = farmerLogic;
    }
    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(RegisterFarmerDto farmerDto)
    {
        try
        {
            string farmer = await FarmerLogic.CreateAsync(farmerDto);
            return Ok(farmer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}