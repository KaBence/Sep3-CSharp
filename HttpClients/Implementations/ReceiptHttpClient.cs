using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Basics;
using Shared.Models;

namespace HttpClients.Implementations;

public class ReceiptHttpClient: IReceiptService
{
    private readonly HttpClient client;

    public ReceiptHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    
    public async Task<IEnumerable<SendReceiptDto>> GetPendingReceiptsByFarmer(string farmName)
    {
      
        HttpResponseMessage response = await client.GetAsync($"Receipt/PendingByFarmer/{farmName}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<SendReceiptDto> receipts = JsonSerializer.Deserialize<ICollection<SendReceiptDto>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return receipts;

    }

    public Task<IEnumerable<Receipt>> GetApprovedReceiptsByFArmer(SendReceiptDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Receipt>> GetRejectedREceiptsByFArmer(SendReceiptDto dto)
    {
        throw new NotImplementedException();
    }
}