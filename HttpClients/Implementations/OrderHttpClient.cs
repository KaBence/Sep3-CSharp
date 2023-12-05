using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Application.LogicInterfaces;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Update;
using Shared.Models;

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

    public async Task<string> AcceptOrder(AcceptOrder order)
    {
        string dtoAsJson = JsonSerializer.Serialize(order);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage res = await client.PatchAsync("/order", body);
        string content = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        return content;
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsFromOrder(int orderId)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"Order/Single/{orderId}");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<OrderItem> items = JsonSerializer.Deserialize<ICollection<OrderItem>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return items;
    }
    
    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsFromGroup(int orderId)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"Order/Group/{orderId}");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<OrderItem> items = JsonSerializer.Deserialize<ICollection<OrderItem>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return items;
    }
}