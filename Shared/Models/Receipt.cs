namespace Shared.Models;

public class Receipt
{
    public int OrderID { get; set; }
    public bool Processed { get; set; }
    public string status { get; set; }
    public double price { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentDate { get; set; }
    public string Text { get; set; }
    public string FarmerID { get; set; }
    public string CustomerID { get; set; }
}