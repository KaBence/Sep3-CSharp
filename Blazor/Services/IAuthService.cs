using System.Security.Claims;
using Shared.DTOs;

namespace Blazor.Services;

public interface IAuthService
{
    Task LoginAsync(LoginDto dto);
    Task LogoutAsync();
    Task<ClaimsPrincipal> GetAuthAsync();

    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}