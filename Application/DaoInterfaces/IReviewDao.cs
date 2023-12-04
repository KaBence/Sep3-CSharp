using Shared.DTOs.Create;
using Shared.Models;
namespace Application.DaoInterfaces;

public interface IReviewDao
{
    Task<string> CreateAsync(ReviewCreateDto alien);
    Task<IEnumerable<Review>> GetAllAsync(string farmer);
    Task<string> PostComment(CommentCreateDto comment);
}