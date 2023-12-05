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
  
    public async Task<IEnumerable<CustomerSendReceiptDto>> GetReceiptsByCustomerAsync(string customerId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetReceiptsByCustomerRequest(customerId);
        try
        { 
            getReceiptsByCustomerResponse response = client.getCustomersReceipt(request);
            List<Receipt> receipts = new List<Receipt>();
            List<string> farmerNames = new List<string>();
            List<CustomerSendReceiptDto> dto = new List<CustomerSendReceiptDto>();
            foreach (var item in response.Receipts)
            {
                receipts = new List<Receipt>();
                farmerNames = new List<string>();
                foreach (var item2 in item.Receipts)
                {
                    receipts.Add(DTOFactory.toReceipt(item2));
                }

                foreach (var item2 in item.FarmNames)
                {
                    farmerNames.Add(item2);
                }

                double combinedPrice = item.CombinedPrice;
                string dateOfCreation = item.DateOfCreation;
                
                dto.Add(new CustomerSendReceiptDto
                {
                    combinedPrice = combinedPrice,
                    dateOfCreation = dateOfCreation,
                    farmNames = farmerNames,
                    Receipts = receipts
                });
            }

            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<SendReceiptDto>> GetPendingReceiptsAsync(string farmerId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetPendingReceiptsByFarmerRequest(farmerId);
        try
        {
            var response = client.getPendingFarmersReceipt(request);
          //  SendReceiptDto sendReceiptDto = new SendReceiptDto();
            List<SendReceiptDto> pendingReceipts = new List<SendReceiptDto>();
            foreach (var item in response.Receipts)
            {
                Receipt receipt = DTOFactory.toReceipt(item.Receipt);
                    string creationDate = item.DateOfCreation;
                    pendingReceipts.Add(new SendReceiptDto
                    {
                        dateOfCreation = creationDate,
                        Receipt = receipt
                    });
            }

            return pendingReceipts;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<SendReceiptDto>> GetAcceptedReceipts(string farmerId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetApprovedReceiptsByFarmerRequest(farmerId);
        try
        {
            var response = client.getApprovedFarmersReceipt(request);
            List<SendReceiptDto> ApprovedReceipts = new List<SendReceiptDto>();
            foreach (var item in response.Receipts)
            {
                Receipt receipt = DTOFactory.toReceipt(item.Receipt);
                string creationDate = item.DateOfCreation;
                ApprovedReceipts.Add(new SendReceiptDto
                {
                    dateOfCreation = creationDate,
                    Receipt = receipt
                });
            }

            return ApprovedReceipts;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<SendReceiptDto>> GetRejectedReceipts(string farmerId)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetRejectedReceiptsByFarmerRequest(farmerId);
        try
        {
            var response = client.getRejectedFarmersReceipt(request);
            List<SendReceiptDto> RejectedReceipts = new List<SendReceiptDto>();
            foreach (var item in response.Receipts)
            {
                Receipt receipt = DTOFactory.toReceipt(item.Receipt);
                string creationDate = item.DateOfCreation;
                RejectedReceipts.Add(new SendReceiptDto
                {
                    dateOfCreation = creationDate,
                    Receipt = receipt
                });
            }

            return RejectedReceipts;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}