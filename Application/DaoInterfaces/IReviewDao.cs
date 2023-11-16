using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IReviewDao
{
    Task<Review> CreateAsync(Review alien);
    Task<Review?> GetByIdAsync(int farmerId,int customerId);
    Task<IEnumerable<Review>> GetAsync(SearchReviewDto searchParameters);

    Task UpdateAsync(Comment comment);
}