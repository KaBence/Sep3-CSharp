using System.Security.Claims;
using System.Text;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;

namespace Blazor.Services.Http;

public class JwtAuthService:IAuthService
{
    
    private readonly HttpClient client;
    private readonly IUserService userService;
    public static string? Jwt { get; private set; } = "";

    public JwtAuthService(HttpClient client, IUserService userService)
    {
        this.client = client;
        this.userService = userService;
    }

    public async Task LoginAsync(LoginDto dto)
    {
        string userAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync("/auth/login", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        string token = responseContent;
        Jwt = token;

        ClaimsPrincipal principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }

    public async Task LogoutAsync()
    {
        Jwt = null;
        OnAuthStateChanged.Invoke(new ClaimsPrincipal());
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }
}