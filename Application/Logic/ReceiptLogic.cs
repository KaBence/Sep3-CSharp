using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ReceiptLogic:IReceiptLogic
{
    private readonly IReceiptDao receiptDao;

    public ReceiptLogic(IReceiptDao receiptDao)
    {
        this.receiptDao = receiptDao;
    }


    public async Task<string> CreateAsync(ReceiptCreateDto dto)
    {
        try
        {
            string created = await receiptDao.CreateAsync(dto);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Receipt>> GetAsync(SearchReceiptDto searchParameters)
    {
        return await receiptDao.GetAsync(searchParameters);
    }

    public async Task<Receipt?> GetByIdAsync(int id)
    {
        return await receiptDao.GetByIdAsync(id);
    }

    public async Task<Receipt?> GetByIdAsync(int orderId,int farmerId,int customerId)
    {
        return await receiptDao.GetByIdAsync(orderId, farmerId,customerId);
    }
    
    
}