using Application.Logic;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IReviewLogic
{
    Task<Review> CreateAsync(ReviewCreateDto dto);
    
    Task<IEnumerable<Review>> GetAsync(SearchReviewDto searchParameters);
    Task<Review?> GetByIdAsync(int id);

    
    Task DeleteAsync(int id);

    Task UpdateAsync(Comment dto);
}