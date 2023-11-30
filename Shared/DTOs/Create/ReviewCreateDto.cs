using Shared.Models;

namespace Shared.DTOs.Create;

public class ReviewCreateDto
{
    public ReviewCreateDto(string text, double star, string farmerId, string customerId, List<Comment> comments)
    {
        Text = text;
        Star = star;
        FarmerId = farmerId;
        CustomerId = customerId;
        Comments = comments;
    }

    public string Text { get; set; }
    public double Star { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }
    public List<Comment> Comments { get; set; }

    public ReviewCreateDto()
    {
        
    }
   
}