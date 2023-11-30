namespace Shared.DTOs.Search;

public class SearchReceiptDto
{
    public int OrderID { get; set; }
    public double Amount { get; set; }
    public double Price { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentDate { get; set; }
    public string Text { get; set; }
    public string FarmerID { get; set; }
    public string CustomerID { get; set; }

    public SearchReceiptDto()
    {
        
    }

    public SearchReceiptDto(string customerID)
    {
        CustomerID = customerID;
    }
    

    public SearchReceiptDto(int orderId, double amount, double price, string paymentMethod, string paymentDate,
        string text, string farmerId, string customerId)
    {
        OrderID = orderId;
        Amount = amount;
        Price = price;
        PaymentMethod = paymentMethod;
        PaymentDate = paymentDate;
        Text = text;
        FarmerID = farmerId;
        CustomerID = customerId;
    }
}