using Shared.DTOs.Create;
using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IReceiptDao
{
    Task<string> CreateAsync(ReceiptCreateDto alien);
    Task<Receipt?> GetByIdAsync(int orderId,int farmerId,int customerId);
    Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters);
    Task<Receipt?> GetByIdAsync(int orderId);
}