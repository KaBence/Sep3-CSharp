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
            var response = client.getCustomersReceipt(request);
            List<Receipt> receipts = new List<Receipt>();
            List<string> farmerNames = new List<string>();
            List<CustomerSendReceiptDto> dto = new List<CustomerSendReceiptDto>();
            foreach (var item in response.Receipts)
            {
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

   
}