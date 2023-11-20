﻿using System.Globalization;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task Register(RegisterCustomerDto dto);
    Task Register(RegisterFarmerDto dto);

    Task EditUser(EditUserDto dto);

    Task<EditUserDto> GetByIdAsync(string phoneNumber);
}