using Shared.Models;
using Shared.DTOs.Search;
namespace Application.DaoInterfaces;

public interface IReceiptDao
{
    Task<Receipt> CreateAsync(Receipt alien);
    Task<Receipt?> GetByIdAsync(int orderId,int farmerId,int customerId);
    Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters);
}