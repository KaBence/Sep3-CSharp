using System.Diagnostics;
using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Basics;
using Shared.Models;

namespace gRPCData.DAOs;

public class ReceiptDao: IReceiptDao
{
    public Task<IEnumerable<SendReceiptBasicDto>> GetReceiptsByFarmerAsync(string farmerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SendReceiptBasicDto>> GetReceiptsByCustomerAsync(string customerId)
    {
        throw new NotImplementedException();
    }

    public Task<string> DtoSentReceiptsAsync()
    {
        throw new NotImplementedException();
    }
}