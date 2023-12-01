using Application.Logic;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IReceiptLogic
{
    Task<IEnumerable<CustomerSendReceiptDto>> GetAllReceiptsByCustomerAsync(string customerId);

    Task<IEnumerable<SendReceiptDto>> getPendingReceipts(string farmerId);
    Task<IEnumerable<SendReceiptDto>> getAcceptedReceipts(string farmerId);
    Task<IEnumerable<SendReceiptDto>> GetRejectedReceipts(string farmerId);
}