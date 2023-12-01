using System.Collections;
using Sep;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IReceiptDao
{
   Task<IEnumerable<CustomerSendReceiptDto>> GetReceiptsByCustomerAsync(string customerId);
  Task<IEnumerable<SendReceiptDto>> GetPendingReceiptsAsync(string farmerId);
  Task<IEnumerable<SendReceiptDto>> GetAcceptedReceipts(string farmerId);
  Task<IEnumerable<SendReceiptDto>> GetRejectedReceipts(string farmerId);
}