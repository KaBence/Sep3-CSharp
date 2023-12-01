using System.Collections;
using Sep;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IReceiptDao
{
    
   // Task<IEnumerable<SendReceiptBasicDto>> GetReceiptsByFarmerAsync(string farmerId);
    Task<IEnumerable<CustomerSendReceiptDto> >GetReceiptsByCustomerAsync(string customerId);
    
  //  Task<string> DtoSentReceiptsAsync();
    
    


}