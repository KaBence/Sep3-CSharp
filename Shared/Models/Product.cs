namespace Shared.Models;

public class Product
{
    public int ProductID { get; set; }
    public bool availability { get; set; }
    public int amount { get; set; }
    public string type { get; set; }
    public double price { get; set; }
    public string PickedDate { get; set; }
    public string ExpirationDate { get; set; }
    public string FarmerID { get; set; }
}