using Shared.DTOs.Create;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IReviewServices
{
    Task<string> CreateReview(ReviewCreateDto dto);
    Task<string> PostComment(CommentCreateDto dto);
    Task<IEnumerable<Review>> GetReviewsByFarmer(string farmer);
}