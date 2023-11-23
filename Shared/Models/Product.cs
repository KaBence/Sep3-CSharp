namespace Shared.Models;

public class Product
{
    public int ProductID { get; set; }
    public bool Availability { get; set; }
    public double Amount { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string PickedDate { get; set; }
    public string ExpirationDate { get; set; }
    public string FarmerID { get; set; }
}