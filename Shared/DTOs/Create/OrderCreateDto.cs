using Shared.Models;

namespace Shared.DTOs.Create;

public class OrderCreateDto
{
    public string CustomerID { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public string PaymentMethod { get; set; }
    public string Note { get; set; }

    public OrderCreateDto(string customerId, List<OrderItem> orderItems, string paymentMethod, string note)
    {
        CustomerID = customerId;
        OrderItems = orderItems;
        PaymentMethod = paymentMethod;
        Note = note;
    }

    public OrderCreateDto()
    {
    }
}