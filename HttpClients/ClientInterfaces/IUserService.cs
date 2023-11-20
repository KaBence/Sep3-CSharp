﻿using System.Globalization;
using System.Threading.Tasks;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<string> Register(RegisterCustomerDto dto);
    Task Register(RegisterFarmerDto dto);

    Task EditUser(EditUserDto dto);

    Task<EditUserDto> GetByIdAsync(string phoneNumber);
}