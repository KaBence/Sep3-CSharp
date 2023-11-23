using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class UserHttpClient: IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async  Task<string> Register(RegisterCustomerDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/customer", dto);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return content;
    }

    public async  Task <string> Register(RegisterFarmerDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/farmer", dto);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
            
        }

        return content;
    }

    public async Task<string> EditFarmer(EditFarmerDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage res = await client.PatchAsync("/farmer", body);
        string content = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        return content;
    }

    public async Task<string> EditCustomer(EditCustomerDto dto)
    {
        //Console.WriteLine(dto.FirstName);
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage res = await client.PatchAsync("/customer", body);
        string content = await res.Content.ReadAsStringAsync();
        
        if (!res.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        return content;
    }

    public async Task<EditCustomerDto> GetCustomerByIdAsync(string phoneNumber)
    {
        HttpResponseMessage response = await client.GetAsync($"/Customer/{phoneNumber}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        EditCustomerDto user = JsonSerializer.Deserialize<EditCustomerDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
    
    public async Task<EditFarmerDto> GetFarmerByIdAsync(string phoneNumber)
    {
        HttpResponseMessage response = await client.GetAsync($"/Farmer/{phoneNumber}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        EditFarmerDto user = JsonSerializer.Deserialize<EditFarmerDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
}