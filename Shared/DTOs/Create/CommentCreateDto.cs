namespace Shared.DTOs.Create;

public class CommentCreateDto
{
    public CommentCreateDto(string text, string farmerId, string customerId)
    {
        Text = text;
        FarmerId = farmerId;
        CustomerId = customerId;
    }

    public string Text { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }

    public CommentCreateDto()
    {
        
    }
}