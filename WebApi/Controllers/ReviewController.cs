using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Sep;
using Shared.DTOs.Create;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewLogic reviewLogic;
    
    public ReviewController(IReviewLogic reviewLogic)
    {
        this.reviewLogic = reviewLogic;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(ReviewCreateDto dto)
    {
        try
        {
            string product = await reviewLogic.CreateAsync(dto);
            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{farmer:required}")]
    public async Task<ActionResult<IEnumerable<Review>>> GetByFarmerAsync([FromRoute] string farmer)
    {
        try
        {
            IEnumerable<Review> reviews = await reviewLogic.GetAllAsync(farmer);
            return Ok(reviews);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("/Comment")]
    public async Task<ActionResult<string>> CreateCommentAsync(CommentCreateDto dto)
    {
        try
        {
            string product = await reviewLogic.CreateCommentAsync(dto);
            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}