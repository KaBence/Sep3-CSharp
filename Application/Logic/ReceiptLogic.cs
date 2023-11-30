using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.Logic;

public class ReceiptLogic : IReceiptLogic
{
    private readonly IReceiptDao receiptDao;

    public ReceiptLogic(IReceiptDao receiptDao)
    {
        this.receiptDao = receiptDao;
    }



    
    
}