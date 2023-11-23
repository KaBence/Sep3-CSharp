using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Application.DaoInterfaces;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace HttpClients.Implementations;

public class ProductHttpClient : IProductService
{
    private readonly HttpClient client;

    public ProductHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<string> CreateProductAsync(ProductCreateDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/product", dto);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return content;
    }

    public async Task EditProduct(UpdateProductDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage res = await client.PatchAsync("/product", body);
        if (!res.IsSuccessStatusCode)
        {
            string content = await res.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}