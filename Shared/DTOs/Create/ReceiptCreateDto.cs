namespace Shared.DTOs.Create;

public class ReceiptCreateDto
{
    public double Amount { get; set; }
    public double Price { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentDate { get; set; }
    public string Text { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }
    
    public ReceiptCreateDto(double amount, double price, string paymentMethod, string paymentDate, string text, string farmerId, string customerId)
    {
        Amount = amount;
        Price = price;
        PaymentMethod = paymentMethod;
        PaymentDate = paymentDate;
        Text = text;
        FarmerId = farmerId;
        CustomerId = customerId;
    }

    public ReceiptCreateDto()
    {
        
    }
    
}
