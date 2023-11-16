using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class ReviewDao: IReviewDao
{
    public Task<Review> CreateAsync(Review alien)
    {
        throw new NotImplementedException();
    }

    public Task<Review?> GetByIdAsync(int farmerId, int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetAsync(SearchReviewDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }
}