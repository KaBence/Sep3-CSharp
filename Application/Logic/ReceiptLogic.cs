using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ReceiptLogic:IReceiptLogic
{
    public Task<Receipt> CreateAsync(ReceiptCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Receipt?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}