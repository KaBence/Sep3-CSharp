namespace Shared.Models;

public class OrderItem
{
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public double Amount { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string FarmerName { get; set; }

    public OrderItem(int productId, string type,double amount, double price, string farmerName)
    {
        
        ProductID = productId;
        Amount = amount;
        Type = type;
        Price = price;
        FarmerName = farmerName;

    }
}