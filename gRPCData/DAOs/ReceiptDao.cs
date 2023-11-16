using Application.DaoInterfaces;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class ReceiptDao: IReceiptDao
{
    public Task<Receipt> CreateAsync(Receipt alien)
    {
        throw new NotImplementedException();
    }

    public Task<Receipt?> GetByIdAsync(int orderId, int farmerId, int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters)
    {
        throw new NotImplementedException();
    }
}