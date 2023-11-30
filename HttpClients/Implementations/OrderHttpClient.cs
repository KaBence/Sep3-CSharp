using System.Net.Http.Json;
using Application.LogicInterfaces;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Create;

public class OrderHttpClient : IOrderService
{
    private readonly HttpClient client;

    public OrderHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<string> CreateOrderAsync(OrderCreateDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/order", dto);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return content;
    }
}