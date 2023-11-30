using Application.Logic;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IReceiptLogic
{
    Task<string> CreateAsync(ReceiptCreateDto dto);
    
    Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters);
    Task<Receipt?> GetByIdAsync(int id);

    
}