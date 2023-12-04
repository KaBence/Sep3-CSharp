namespace Shared.DTOs;

public class OrderItemDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double amount { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string FarmName { get; set; }
}