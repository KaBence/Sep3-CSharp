using Shared.Models;

namespace Shared.DTOs.Basics;

public class SendReceiptBasicDto
{
    public Receipt receipt { get; set; }
    public List<OrderItem> list { get; set; }
    
    
}