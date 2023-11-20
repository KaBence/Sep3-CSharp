using System.Text;
using System.Text.Json;
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

    public Task Register(RegisterCustomerDto dto)
    {
        throw new NotImplementedException();
    }

    public Task Register(RegisterFarmerDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task EditUser(EditUserDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage res = await client.PatchAsync("/!!!!!!!!!", body);
        if (!res.IsSuccessStatusCode)
        {
            string content = await res.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<EditUserDto> GetByIdAsync(string phoneNumber)
    {
        HttpResponseMessage response = await client.GetAsync($"!!!!!!!!!");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        EditUserDto user = JsonSerializer.Deserialize<EditUserDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
}