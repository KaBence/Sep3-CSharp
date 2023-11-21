﻿using System.Net.Http.Json;
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