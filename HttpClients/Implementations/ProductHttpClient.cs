using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Application.DaoInterfaces;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

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

    public async Task<IEnumerable<Product>> getAsync(SearchProductDto searchParameters)
    {
        string query = ConstructQuery(searchParameters);
        
        HttpResponseMessage response = await client.GetAsync("/product"+query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Product> todos = JsonSerializer.Deserialize<ICollection<Product>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return todos;
    }
    
    private static string ConstructQuery(SearchProductDto searchParameters)
    {
        string query = "";
        if (!string.IsNullOrEmpty(searchParameters.Type))
        {
            query += $"?type={searchParameters.Type}";
        }
        if (searchParameters.Price != 0)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"Price={searchParameters.Price}";
        }

        if (searchParameters.Amount != 0)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"amount={searchParameters.Amount}";
        }

        

        return query;
    }
}