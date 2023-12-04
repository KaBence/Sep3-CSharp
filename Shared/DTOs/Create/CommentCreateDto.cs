namespace Shared.DTOs.Create;

public class CommentCreateDto
{
    public string Text { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }
    public int OrderId { get; set; }
    public string Username { get; set; }

    public CommentCreateDto(string text, string farmerId, string customerId, int orderId, string username)
    {
        Text = text;
        FarmerId = farmerId;
        CustomerId = customerId;
        OrderId = orderId;
        Username = username;
    }
    
    public CommentCreateDto() {}
}