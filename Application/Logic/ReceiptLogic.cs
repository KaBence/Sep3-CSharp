using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.Basics;

namespace Application.Logic;

public class ReceiptLogic : IReceiptLogic
{
    private readonly IReceiptDao receiptDao;

    public ReceiptLogic(IReceiptDao receiptDao)
    {
        this.receiptDao = receiptDao;
    }

    public Task<IEnumerable<CustomerSendReceiptDto>> GetAllReceiptsByCustomerAsync(string customerId)
    {
        return receiptDao.GetReceiptsByCustomerAsync(customerId);
    }

    public Task<IEnumerable<SendReceiptDto>> getPendingReceipts(string farmerId)
    {
        return receiptDao.GetPendingReceiptsAsync(farmerId);
    }

    public Task<IEnumerable<SendReceiptDto>> getAcceptedReceipts(string farmerId)
    {
        return receiptDao.GetAcceptedReceipts(farmerId);
    }

    public Task<IEnumerable<SendReceiptDto>> GetRejectedReceipts(string farmerId)
    {
        return receiptDao.GetRejectedReceipts(farmerId);
    }
}