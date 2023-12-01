using Shared.Models;

namespace Shared.DTOs.Basics;

public class SendReceiptDto
{
    public Receipt Receipt { get; set; }
    public string dateOfCreation { get; set; }
}