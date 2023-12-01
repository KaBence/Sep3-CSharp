using Shared.Models;

namespace Shared.DTOs.Create;

public class ReviewCreateDto
{
    public string Text { get; set; }
    public double Star { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }
    public int OrderId { get; set; }
    public List<Comment> Comments { get; set; }

    public ReviewCreateDto(string text, double star, string farmerId, string customerId, int orderId, List<Comment> comments)
    {
        Text = text;
        Star = star;
        FarmerId = farmerId;
        CustomerId = customerId;
        OrderId = orderId;
        Comments = comments;
    }
    
    public ReviewCreateDto()
    {
        
    }
   
}