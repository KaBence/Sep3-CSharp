using Application.DaoInterfaces;
using Shared.DTOs;

namespace WebApi.Services;

public class AuthService:IAuthService
{
    private readonly ILoginDao loginDao;

    public AuthService(ILoginDao loginDao)
    {
        this.loginDao = loginDao;
    }

    public async Task<LoginSuccessDto> getUser(LoginDto dto)
    {
        LoginSuccessDto? existingUser = await loginDao.GetSuccess(dto);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (existingUser.PhoneNumber.Contains("Exception"))
        {
            throw new Exception(existingUser.PhoneNumber);
        }

        return existingUser;
    }
}