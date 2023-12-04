using Shared.DTOs.Basics;

namespace Application.LogicInterfaces;

public interface IReceiptLogic
{
    Task<IEnumerable<CustomerSendReceiptDto>> GetAllReceiptsByCustomerAsync(string customerId);
    Task<IEnumerable<SendReceiptDto>> getPendingReceipts(string farmerId);
    Task<IEnumerable<SendReceiptDto>> getAcceptedReceipts(string farmerId);
    Task<IEnumerable<SendReceiptDto>> GetRejectedReceipts(string farmerId);
}