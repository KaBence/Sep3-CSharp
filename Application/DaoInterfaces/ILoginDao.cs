using Shared.DTOs;

namespace Application.DaoInterfaces;

public interface ILoginDao
{
    Task<LoginSuccessDto> GetSuccess(LoginDto dto);
}