using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ReviewLogic: IReviewLogic
{
    public Task<Review> CreateAsync(ReviewCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetAsync(SearchReviewDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Review?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment dto)
    {
        throw new NotImplementedException();
    }
}