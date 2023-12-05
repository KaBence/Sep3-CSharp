using Shared.DTOs.Basics;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IReceiptService
{
    Task<IEnumerable<SendReceiptDto>> GetPendingReceiptsByFarmer(string farmName);
    Task<IEnumerable<SendReceiptDto>> GetAcceptedReceiptsByFarmer(string farmName);
    Task<IEnumerable<SendReceiptDto>> GetRejectedReceiptsByFarmer(string farmName);

    Task<IEnumerable<CustomerSendReceiptDto>> getCustomerReceipts(string customerId);

}