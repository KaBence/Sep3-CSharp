using System.Globalization;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<string> Register(RegisterCustomerDto dto);
    Task<string> Register(RegisterFarmerDto dto);

    Task EditUser(EditUserDto dto);

    Task<EditUserDto> GetByIdAsync(string phoneNumber);
}