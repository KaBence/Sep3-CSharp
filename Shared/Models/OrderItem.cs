namespace Shared.Models;

public class OrderItem
{
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public double amount { get; set; }
}