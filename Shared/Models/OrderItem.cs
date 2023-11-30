namespace Shared.Models;

public class OrderItem
{
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public double Amount { get; set; }

    public OrderItem(int orderId, int productId, double amount)
    {
        OrderID = orderId;
        ProductID = productId;
        Amount = amount;
    }

    public OrderItem()
    {
    }
}