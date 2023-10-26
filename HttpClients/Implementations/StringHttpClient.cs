
using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations
{
    public class StringHttpClient : IStringService
    {
        private readonly HttpClient client;

        public StringHttpClient(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task CreateAsync(string dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/string",dto);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }

        public async Task<ICollection<string>> GetAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/post");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<string> posts = JsonSerializer.Deserialize<ICollection<string>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return posts;
        }
    }
}