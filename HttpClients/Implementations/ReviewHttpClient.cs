using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs.Create;
using Shared.Models;

namespace HttpClients.Implementations;

public class ReviewHttpClient:IReviewServices
{
    private readonly HttpClient client;

    public ReviewHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<string> CreateReviewAsync(ReviewCreateDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/review", dto);
        string content = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return content;
    }

    public Task<string> PostComment(CommentCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Review>> GetReviewsByFarmer(string farmer)
    {
        HttpResponseMessage response = await client.GetAsync($"/Review/{farmer}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Review> reviews = JsonSerializer.Deserialize<ICollection<Review>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return reviews;
    }
}