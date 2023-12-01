using Application.Logic;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IReceiptLogic
{
    Task<IEnumerable<CustomerSendReceiptDto>> GetAllReceiptsByCustomerAsync(string customerId);
}