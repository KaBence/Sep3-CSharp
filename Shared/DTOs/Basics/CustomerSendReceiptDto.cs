using Shared.Models;

namespace Shared.DTOs.Basics;

public class CustomerSendReceiptDto
{
    public IEnumerable<string> farmNames { get; set; }
    public double combinedPrice { get; set; }
    public string dateOfCreation { get; set; }
    public IEnumerable<Receipt> Receipts { get; set; }
    
}