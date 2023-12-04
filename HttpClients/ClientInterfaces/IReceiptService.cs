using Shared.DTOs.Basics;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IReceiptService
{
    Task<IEnumerable<SendReceiptDto>> GetPendingReceiptsByFarmer(string farmName);
    Task<IEnumerable<Receipt>> GetApprovedReceiptsByFArmer(SendReceiptDto dto);
    Task<IEnumerable<Receipt>> GetRejectedREceiptsByFArmer(SendReceiptDto dto);

}