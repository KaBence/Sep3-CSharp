
using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations
{
    public class StringHttpClient : IStringService
    {
        private readonly HttpClient client;

        public StringHttpClient(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task CreateAsync(AlienCreationDto dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/aliens",dto);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }

        public async Task<ICollection<Alien>> GetAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/aliens");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<Alien> posts = JsonSerializer.Deserialize<ICollection<Alien>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return posts;
        }
    }
}