using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Sep;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ReviewLogic: IReviewLogic
{
    private readonly IReviewDao reviewDao;

    public ReviewLogic(IReviewDao reviewDao)
    {
        this.reviewDao = reviewDao;
    }
    public async Task<string> CreateAsync(ReviewCreateDto dto)
    {
        try
        {
            string created = await reviewDao.CreateAsync(dto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Review>> GetAllAsync(string farmer)
    {
        try
        {
            IEnumerable<Review> list = await reviewDao.GetAllAsync(farmer);
            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> CreateCommentAsync(CommentCreateDto dto)
    {
        try
        {
            string created = await reviewDao.PostComment(dto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}