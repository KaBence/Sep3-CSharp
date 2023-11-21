using Shared.DTOs;

namespace WebApi.Services;

public interface IAuthService
{
    Task<LoginSuccessDto> getUser(LoginDto dto);
}