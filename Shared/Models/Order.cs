namespace Shared.Models;

public class Order
{
    public int OrderID { get; set; }
    public string Status { get; set; }
    public string Date { get; set; }
    public string CustomerID { get; set; }
}